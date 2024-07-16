using MachineTest.Interfaces;
using MachineTest.Models;
using MachineTest.ViewModel;
using MachineTest.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MachineTest.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly IEmployeeRepository _empRepository;
        public EmployeeServices(IEmployeeRepository empRepository)
        {
            _empRepository= empRepository;
        }
        public List<Employee> GetAllEmployee()
        {
            return _empRepository.GetAllEmployee();
        }
        public bool AddEmployee(Employee emp)
        {
            return _empRepository.AddEmployee(emp);
        }
        public bool UpdateEmployee(Guid Id,Employee emp)
        {
            return _empRepository.UpdateEmployee(Id,emp);
        }
        
        public bool DeleteEmployee(Guid Id)
        {
            return _empRepository.DeleteEmployee(Id);
        }
        public Employee GetEmployeeById(Guid Id)
        {
            return _empRepository.GetEmployeeById(Id);
        }
       public List<string> GetDistinctDepartments()
        {
            return _empRepository.GetDistinctDepartments();
        }
        public List<Employee> GetByDept(string Dept)
        {
            return _empRepository.GetByDept(Dept);
        }



    }
}
