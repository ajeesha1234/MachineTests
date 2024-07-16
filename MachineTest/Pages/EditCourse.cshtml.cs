using MachineTest.Interfaces;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MachineTest.Pages
{
    public class EditCourseModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        private readonly ICourseServices _courseService;

        public EditCourseModel(ICourseServices courseService)
        {
            _courseService = courseService;
        }
        public void OnGet()
        {
            Course = _courseService.GetCourseById(Id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(Id, Course);
                return LocalRedirect("~/Course");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            _courseService.DeleteCourse(Id);
            return LocalRedirect("~/Course");
        }
    }
}
