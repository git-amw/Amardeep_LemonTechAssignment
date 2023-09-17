using Amardeep_LemonTechAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Amardeep_LemonTechAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<Node> Nodes { get; set; }
    }
}
