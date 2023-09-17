using System.ComponentModel.DataAnnotations;

namespace Amardeep_LemonTechAssignment.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }

        [Required]
        public string? NodeName { get; set; }

        public int? ParentNodeId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string StartDate { get; set; }
    }
}
