using System.Collections.Generic;
using System.Linq;
using EmployeeData;
using EmployeeData.Models;

namespace EmployeeManager.data
{
    public class EmployeeDataManager : IEmployeeDataManager
    {
        private readonly AppDbContext _context;

        public EmployeeDataManager(AppDbContext context)
        {
            _context = context;
        }
        
        public Employee Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _context.Employees.ToList();

            return employees;
        }

        public Employee GetById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            return employee;
        }

        public void DeleteById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Employees.Remove(employee);
                _context.SaveChanges();
        }

        public Employee UpdateById(Employee employee)
        {
            var updatedEmployee = _context.Employees.Attach(employee);
            updatedEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return employee;
        }
    }
}