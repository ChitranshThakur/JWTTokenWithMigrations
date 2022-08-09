using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenWithMigrations.Interface;
using TokenWithMigrations.Models;

namespace TokenWithMigrations.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployees _employees;
        public EmployeeController(IEmployees employees)
        {
            _employees = employees;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        { 
           return await Task.FromResult(_employees.GetEmployeeDetails());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        { 
            var employee = await Task.FromResult(_employees.GetEmployeeDetails(id));
            if (employee == null)
            { 
               return NotFound();
            }
            return employee;        
        }

        [HttpPost("addemployee")]

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            _employees.AddEmployee(employee);
            return await Task.FromResult(employee);

        }

        [HttpPut("update/{id}")]

        public async Task<ActionResult<Employee>> UpdateEmployee(int id)
        { 
            var UtEmp = await Task.FromResult(_employees.GetEmployeeDetails(id));
            if (UtEmp == null)
            {
                return NotFound();
            }
            _employees.UpdateEmployee(UtEmp);
            return await Task.FromResult(UtEmp);
        
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _employees.DeleteEmployee(id);
            return Json(new { message = "Employee Deleted." }); 
        }

    }
}
