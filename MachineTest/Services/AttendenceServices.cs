using MachineTest.Interfaces;
using MachineTest.Models;
namespace MachineTest.Services
{
    public class AttendenceServices:IAttendenceServices
    {
        private readonly IAttendenceRepository _attendenceRepo;
        public AttendenceServices(IAttendenceRepository attendenceRepo)
        {
            _attendenceRepo = attendenceRepo;
        }   
        public bool AddAttendence(Attendence att)
        {
            return _attendenceRepo.AddAttendence(att);
        }
    }
}
