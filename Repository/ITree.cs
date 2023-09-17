using Amardeep_LemonTechAssignment.Models;

namespace Amardeep_LemonTechAssignment.Repository
{
    public interface ITree
    {
        Task<bool> AddNode(Node nodeValue);

        Task<bool> UpdateNode(Node nodeValue);

        Task<bool> DeleteNode(int Id);

        Task<List<Node>> GetAllNodes();

        Task<Node> GetNodeById(int Id);

        Task<List<Node>> GetParentNodes();

        Task<List<Tree>> BuildTree(int parentNodeId);
    }
}
