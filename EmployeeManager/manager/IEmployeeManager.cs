using System.Collections.Generic;
using EmployeeData.Models;

namespace EmployeeManager.manager
{
    public interface IEmployeeManager
    {
        Employee CreateEmployee(Employee employee);
        
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(int id);
    }
}