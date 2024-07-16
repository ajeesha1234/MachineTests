using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineTest.ViewModel
{
    public class EmployeeViewModel
    {
        public Guid SelectedEmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
    }
}
