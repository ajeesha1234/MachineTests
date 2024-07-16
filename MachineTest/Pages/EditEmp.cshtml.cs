using MachineTest.Interfaces;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MachineTest.Pages
{
    public class EditEmpModel : PageModel
    {
        [BindProperty]
        public Employee emp { get; set; }
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }
        private readonly IEmployeeServices _employeeService;

        public EditEmpModel(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }
        public void OnGet()
        {
           emp= _employeeService.GetEmployeeById(Id);
        }
        public async Task<IActionResult>OnPost()
        {
            if(ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(Id, emp);
                return LocalRedirect("~/Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete( Guid id)
        {      
                _employeeService.DeleteEmployee(Id);
                return LocalRedirect("~/Home");
        }
    }
}
