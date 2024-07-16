using MachineTest.Models;
using MachineTest.ViewModel;
using MachineTest.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineTest.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee();
        bool UpdateEmployee(Guid Id, Employee employee);
        bool DeleteEmployee(Guid Id);
        bool AddEmployee(Employee emp);
        Employee GetEmployeeById(Guid Id);
        List<string> GetDistinctDepartments();
        List<Employee> GetByDept(string Dept);
    }
}
