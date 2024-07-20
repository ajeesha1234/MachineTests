namespace MachineTest.ViewModel
{
    public class EmployeeCourseAttendence
    {
        
            public string Employee { get; set; }
            public string Course { get; set; }
            public int Validity { get; set; }
            public int AttendanceCount { get; set; }
            public bool NeedsNotification { get; set; } // New property
        
    }
}
