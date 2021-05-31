using System.Collections.Generic;
using EmployeeData.Models;
using EmployeeManager.data;

namespace EmployeeManager.manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDataManager _dataManager;

        public EmployeeManager(IEmployeeDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        
        public Employee CreateEmployee(Employee employee)
        {
            var newEmployee = _dataManager.Create(employee);

            return newEmployee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _dataManager.GetAll();

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _dataManager.GetById(id);

            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updatedEmployee = _dataManager.UpdateById(employee);

            return employee;
        }

        public void DeleteEmployee(int id)
        {
           _dataManager.DeleteById(id);
        }
    }
}