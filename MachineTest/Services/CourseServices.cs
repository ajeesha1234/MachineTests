using MachineTest.Interfaces;
using MachineTest.Models;
namespace MachineTest.Services
{
    public class CourseServices:ICourseServices
    {
        private readonly ICourseRepository _courseRepo;
        public CourseServices(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public List<Course> GetAllCourse()
        {
            return _courseRepo.GetAllCourse();
        }
    public bool AddCourse(Course course)
        {
            return _courseRepo.AddCourse(course);
        }
        public bool UpdateCourse(Guid Id, Course Course)
        {
            return _courseRepo.UpdateCourse(Id, Course);
        }

    public bool DeleteCourse(Guid Id)
        {
            return _courseRepo.DeleteCourse(Id);
        }
    public Course GetCourseById(Guid Id)
        {
            return _courseRepo.GetCourseById(Id);
        }
    }
}
