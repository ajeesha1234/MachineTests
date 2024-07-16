using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineTest.ViewModel
{
    public class CourseViewModel
    {
        public Guid SelectedCourseId { get; set; }
        public List<SelectListItem> Courses { get; set; }
    }
}
