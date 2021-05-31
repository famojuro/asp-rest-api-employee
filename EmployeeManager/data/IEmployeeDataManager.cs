using System.Collections.Generic;
using EmployeeData.Models;

namespace EmployeeManager.data
{
    public interface IEmployeeDataManager
    {
        Employee Create(Employee employee);
        
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        void DeleteById(int id);

        Employee UpdateById(Employee employee);
    }
    }
