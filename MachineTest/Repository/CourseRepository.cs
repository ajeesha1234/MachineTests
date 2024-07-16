using MachineTest.Interfaces;
using MachineTest.Models;
namespace MachineTest.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly NewContext _context;
        public CourseRepository(NewContext context)
        {
            _context = context;
        }
        public List<Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }
        public bool AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
        public bool UpdateCourse(Guid Id, Course course)
        {
            try
            {
                var courses = _context.Courses.FirstOrDefault(cu => cu.Id == Id);
                if (courses != null)
                {
                    courses.Name = course.Name;
                    courses.Description = course.Description;
                    courses.Validity = course.Validity;
                    courses.StartDate= course.StartDate;
                    _context.Courses.Update(courses);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteCourse(Guid Id)
        {
            try
            {
                var courses = _context.Courses.FirstOrDefault(cu => cu.Id == Id);
                if (courses != null)
                {
                    _context.Courses.Remove(courses);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Course GetCourseById(Guid Id)
        {
            return _context.Courses.FirstOrDefault(cu => cu.Id == Id);
        }

    }
}
