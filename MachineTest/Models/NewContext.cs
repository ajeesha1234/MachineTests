using Microsoft.EntityFrameworkCore;

namespace MachineTest.Models
{
    public class NewContext:DbContext
    {
        public NewContext()
        { }
        public NewContext(DbContextOptions<NewContext>options):base(options)
        { }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Attendence> Attendences { get; set; }

    }
}
