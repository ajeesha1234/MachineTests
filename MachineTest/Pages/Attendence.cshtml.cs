using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MachineTest.ViewModel;
using MachineTest.Models;
using MachineTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MachineTest.Pages
{
    public class AttendenceModel : PageModel
    {
        [BindProperty]
        public Attendence Attendence { get; set; }
        [BindProperty]
       
        public EmployeeViewModel EmployeeViewModel { get; set; }
        [BindProperty]
        public CourseViewModel CourseViewModel { get; set; }
        private readonly IEmployeeServices _empService;
        private readonly ICourseServices _courseService;
        private readonly IAttendenceServices _attendenceService;
        public AttendenceModel(IEmployeeServices empService, ICourseServices courseService, IAttendenceServices attendenceService)
        {
            _empService= empService;
            _courseService= courseService;
            _attendenceService= attendenceService;
        }
        public void OnGet()
        {

            BindDrop();
        }
        public async Task<IActionResult> OnPost()
        {
            Attendence.Emp_ID = EmployeeViewModel.SelectedEmployeeId;
            Attendence.Course_ID=CourseViewModel.SelectedCourseId;
            
               if( _attendenceService.AddAttendence(Attendence))
                {
                    TempData["msg"] = "Attendence Added";
                }
                else
                {
                    TempData["msg"] = "Please Crosscheck ";
                }

            BindDrop();
            return Page();

        }
        public void BindDrop()
        {
            EmployeeViewModel = new EmployeeViewModel
            {
                Employees = _empService.GetAllEmployee()
                                 .Select(emp => new SelectListItem
                                 {
                                     Value = emp.Id.ToString(),
                                     Text = emp.Name
                                 })
                                 .ToList()
            };
            CourseViewModel = new CourseViewModel
            {
                Courses = _courseService.GetAllCourse()
                                .Select(Cou => new SelectListItem
                                {
                                    Value = Cou.Id.ToString(),
                                    Text = Cou.Name
                                })
                                .ToList()
            };
        }
    }
}
