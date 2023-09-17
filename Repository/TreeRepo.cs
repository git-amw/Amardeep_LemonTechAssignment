using Amardeep_LemonTechAssignment.Data;
using Amardeep_LemonTechAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Amardeep_LemonTechAssignment.Repository
{
    public class TreeRepo : ITree
    {
        private readonly AppDbContext db;

        public TreeRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddNode(Node nodeValue)
        {
            await db.Nodes.AddAsync(nodeValue);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNode(int Id)
        {
            await Task.Run(() =>
            {
                Node data =  db.Nodes.FirstOrDefault(u => u.NodeId == Id);
                db.Nodes.Remove(data);
                db.SaveChangesAsync();
            });
            return true;
        }

        public async Task<List<Node>> GetAllNodes()
        {
            List<Node> nodes = await db.Nodes.ToListAsync();
            return nodes;
        }

        public async Task<Node> GetNodeById(int Id)
        {
            Node data = await db.Nodes.FindAsync(Id);
            return data;
        }

        public async Task<List<Node>> GetParentNodes()
        {
            List<Node> parents = await db.Nodes.Where(u => u.ParentNodeId == null).ToListAsync();
            return parents;
        }

        public async Task<List<Tree>> BuildTree(int parentNodeId)
        {
            var result = new List<Tree>();

            var nodes = await db.Nodes.Where(n => n.ParentNodeId == parentNodeId && n.IsActive).ToListAsync();

            foreach (var node in nodes)
            {
                var treeNode = new Tree
                {
                    id = node.NodeId,
                    Name = node.NodeName,
                    Children = await BuildTree(node.NodeId) // Recursive call
                };

                result.Add(treeNode);
            }

            return result;
        }


        public async Task<bool> UpdateNode(Node nodeValue)
        {
            Node data = await db.Nodes.FirstOrDefaultAsync(u => u.NodeId == nodeValue.NodeId);

            data.NodeName = nodeValue.NodeName;
            data.ParentNodeId = nodeValue.ParentNodeId;
            data.StartDate = nodeValue.StartDate;

            await db.SaveChangesAsync();

            return true;
        }
    }
}
