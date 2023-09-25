using ASH_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ASH_Test.DbContexts
{
    public class EmployeeContext : DbContext 
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
