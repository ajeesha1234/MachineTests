using MachineTest.Interfaces;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MachineTest.Pages
{
    public class CourseModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }
        [BindProperty]
        public List<Course> Courses { get; set; }
        private readonly ICourseServices _courseService;

        public CourseModel(ICourseServices courseService)
        {
            _courseService = courseService;
        }
        public string GotoUrl { get; set; }
        public void OnGet()
        {
            Courses = _courseService.GetAllCourse();
        }
        public async Task<IActionResult> OnPost(string returnurl = null)
        {
            
            if (ModelState.IsValid)
            {
                _courseService.AddCourse(Course);
                Courses = _courseService.GetAllCourse();
                //TempData["message"] = "Employee Added Successfully";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error");
                TempData["message"] = "Error Occured";

            }
            return Page();
        }

    }
}
