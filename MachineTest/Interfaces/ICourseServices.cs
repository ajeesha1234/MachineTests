using MachineTest.Models;

namespace MachineTest.Interfaces
{
    public interface ICourseServices
    {
        List<Course> GetAllCourse();
        bool UpdateCourse(Guid Id, Course Course);
        bool DeleteCourse(Guid Id);
        bool AddCourse(Course course);
        Course GetCourseById(Guid Id);
    }
}
