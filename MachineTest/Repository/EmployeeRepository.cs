using MachineTest.Interfaces;
using MachineTest.Models;
using MachineTest.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MachineTest.DTOs;
using static MachineTest.DTOs.EmployeeCourseDto;
namespace MachineTest.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly NewContext _context;
        public EmployeeRepository(NewContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();     
        }
        public bool AddEmployee(Employee emp)
        {
            try 
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                return false;
            }
        }
        public bool UpdateEmployee(Guid Id,Employee employee)
        {
            try
            {
                var emp = _context.Employees.FirstOrDefault(em => em.Id == Id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Position = employee.Position;
                    emp.Department = employee.Department;
                    _context.Employees.Update(emp);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public bool DeleteEmployee(Guid Id)
        {
            try
            {
                var emp = _context.Employees.FirstOrDefault(em => em.Id == Id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) 
            {
                throw ex;  
            }

        }
        public Employee GetEmployeeById(Guid Id)
        {
            return _context.Employees.FirstOrDefault(em => em.Id == Id);     
        }
        public List<string> GetDistinctDepartments()
        {
            var distinctDepartments = _context.Employees
                                            .Select(e => e.Department)
                                            .Distinct()
                                            .ToList();

            return distinctDepartments;
        }
        public List<Employee> GetByDept(string Dept)
        {
            return _context.Employees.Where(emp => emp.Department.ToLower() == Dept.ToLower()).ToList();

        }


    }
}
