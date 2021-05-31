using System;
using System.Collections.Generic;
using System.Net.Mime;
using EmployeeData.Models;
using EmployeeManager.manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                var newEmployee = _employeeManager.CreateEmployee(employee);

                return Created(new Uri(Request.GetDisplayUrl()+ newEmployee.Id.ToString()), newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeManager.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee([FromRoute] string id)
        {
            var employee = _employeeManager.GetEmployeeById(int.Parse(id));
            if (employee != null)
            {
                return Ok(employee); 
            }

            return NotFound($"Employee with id {id} not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] string id)
        {
            try
            {
                _employeeManager.DeleteEmployee(int.Parse(id));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Employee with id {id} not found");
            }
        }
    }
}