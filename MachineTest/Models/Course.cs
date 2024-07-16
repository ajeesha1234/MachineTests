using System.ComponentModel.DataAnnotations;

namespace MachineTest.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Validity { get; set; }
        public DateOnly StartDate { get; set; }
        // Method to check if the course is valid
        public bool IsValid()
        {
            // Get current UTC date with time set to midnight
            DateTime currentDateUtc = DateTime.UtcNow.Date;

            // Convert current UTC date to DateOnly for comparison
            DateOnly currentDate = DateOnly.FromDateTime(currentDateUtc);

            // Calculate the end date by adding validity days to start date
            DateOnly endDate = StartDate.AddDays(Validity);

            // Check if today's date is before or equal to the end date
            return currentDate <= endDate;
        }
    }
}
