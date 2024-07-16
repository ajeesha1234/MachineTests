using MachineTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MachineTest.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MachineTest.Models;

namespace MachineTest.Pages
{
    public class ReportModel : PageModel
    {
        private readonly IEmployeeServices _employeeservices;
        public ReportModel(IEmployeeServices employeeservices)
        {
            _employeeservices = employeeservices;
        }
        [BindProperty]
        public List<Employee> Employees { get; set; }
        
        [BindProperty]

        public List<string> Departments { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedDepartment { get; set; }
        public void OnGet()
        {
            Departments = _employeeservices.GetDistinctDepartments();
        }
        public async Task<IActionResult> OnPost()
        {
            Employees= _employeeservices.GetByDept(SelectedDepartment);
            return Page();
        }
    }
}
