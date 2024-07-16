using MachineTest.Interfaces;
using MachineTest.Models;
using MachineTest.Exceptions;
namespace MachineTest.Repository
{
    public class AttendenceRepository:IAttendenceRepository
    {
        private readonly NewContext _context;
        public AttendenceRepository(NewContext context)
        {
            _context= context;
        }
        public bool AddAttendence(Attendence att)
        {
            try
            {
                var attend = CheckForExist(att);
                if(attend != null) 
                {
                    throw new AttendenceAlreadyAdded();
                }
                else
                {
                    _context.Attendences.Add(att);
                    _context.SaveChanges();
                    return true;
                }
               
            }
            catch(Exception ex)
            {
               
                return false;
            }
        }
        public Attendence CheckForExist(Attendence att)
        {
            return _context.Attendences.FirstOrDefault(at => at.AttendenceDate==att.AttendenceDate && at.Emp_ID == att.Emp_ID && at.Course_ID == att.Course_ID);
        }
    }
}
