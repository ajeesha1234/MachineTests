using MachineTest.Models;

namespace MachineTest.Interfaces
{
    public interface IAttendenceRepository
    {
        bool AddAttendence(Attendence att);
        Attendence CheckForExist(Attendence att);

    }
}
