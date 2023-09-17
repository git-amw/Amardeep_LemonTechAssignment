namespace Amardeep_LemonTechAssignment.Models
{
    public class Tree
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Tree> Children { get; set; }
    }
}
