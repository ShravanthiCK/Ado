using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Data
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options) : base(options)

        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
