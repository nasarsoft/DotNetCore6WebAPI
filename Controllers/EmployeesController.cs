//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;

        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAllEmployees()
        {
          var employees= await  _fullStackDbContext.employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmplyee([FromBody] Employee employeeRequest)
        {
           employeeRequest.id =Guid.NewGuid();
           await _fullStackDbContext.employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employees = await _fullStackDbContext.employees.FirstOrDefaultAsync(x => x.id == id);
            
            if(employees == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employees);
            }
            

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id ,Employee updateEmployeeReqest)
        {
          var employee =await _fullStackDbContext.employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {

            }

            employee.Name= updateEmployeeReqest.Name;
            employee.Email= updateEmployeeReqest.Email;
            employee.Phone= updateEmployeeReqest.Phone; 
            employee.Salary= updateEmployeeReqest.Salary;
            employee.Department= updateEmployeeReqest.Department;
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            _fullStackDbContext.employees.Remove(employee);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
        }

    }
}
