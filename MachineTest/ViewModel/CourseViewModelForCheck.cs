namespace MachineTest.ViewModel
{
    public class CourseViewModelForCheck
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Validity { get; set; }
        public DateOnly StartDate { get; set; }
        public bool IsValid { get; set; }
    }
}
