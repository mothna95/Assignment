using Assignment.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment.Data
{
    public class AssignmentDbContext:DbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
          : base(options)
        {
        }

        public virtual DbSet<Customers> Customer { get; set; }
        public virtual DbSet<Invoices> Invoice { get; set; }
    }
}
