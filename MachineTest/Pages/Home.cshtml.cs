using MachineTest.Interfaces;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MachineTest.Pages
{
    public class HomeModel : PageModel
    {
        [BindProperty]
        public Employee emp { get; set; }
        [BindProperty]
        public List<Employee> Employees { get; set; }
        private readonly IEmployeeServices _employeeService;
       
        public HomeModel(IEmployeeServices employeeService)
        {
            _employeeService=employeeService;
        }
        public string GotoUrl { get; set; }
        public void OnGet()
        {
            Employees= _employeeService.GetAllEmployee();
        }
        public async Task<IActionResult>OnPost(string returnurl=null)
        {
          
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(emp);
                Employees = _employeeService.GetAllEmployee();
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
