using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineTest.Models
{
    public class Attendence
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Employee))]
        public Guid Emp_ID { get; set; }
        [ForeignKey(nameof(Course))]
        public Guid Course_ID { get; set; }
        public DateOnly AttendenceDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Course Course { get; set; }
    }
}
