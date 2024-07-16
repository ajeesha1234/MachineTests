namespace MachineTest.Exceptions
{
    public class AttendenceAlreadyAdded:Exception
    {
        public AttendenceAlreadyAdded():base(string.Format("Already Attendence Added"))
        {

        }
    }
}
