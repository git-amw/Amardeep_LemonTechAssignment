using Amardeep_LemonTechAssignment.Models;
using Amardeep_LemonTechAssignment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amardeep_LemonTechAssignment.Controllers
{
    public class TreeController : Controller
    {
        private readonly ITree tree;

        public TreeController(ITree tree)
        {
            this.tree = tree;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Node nodeValues)
        {
            if (ModelState.IsValid)
            {
                await tree.AddNode(nodeValues);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNodes()
        {
            List<Node> Nodeslist = await tree.GetAllNodes();
            return View(Nodeslist);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNode(int id)
        {
            Node data = await tree.GetNodeById(id);
            TempData["CurrentNodeId"] = data.NodeId;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNode(Node nodeValue)
        {
            nodeValue.NodeId = (int)TempData["CurrentNodeId"];

            if (ModelState.IsValid)
            {
                await tree.UpdateNode(nodeValue);
                return RedirectToAction("GetAllNodes");
            }
            return View(nodeValue);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNode(int id)
        {
            await tree.DeleteNode(id);
            return RedirectToAction("GetAllNodes");
        }

        [HttpGet]
        public async Task<IActionResult> GetParentsNodes()
        {
            List<Node> nodes = await tree.GetParentNodes();
            return View(nodes);
        }

        [HttpGet]
        public async Task<IActionResult> TreeView(int id)
        {

            List<Tree> result = await tree.BuildTree(id);
            return View(result);

        }
        
    }
}
