using System.ComponentModel.DataAnnotations;

namespace MachineTest.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

    }
}
