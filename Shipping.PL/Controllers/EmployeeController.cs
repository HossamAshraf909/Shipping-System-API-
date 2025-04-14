using Azure.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Employee;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
            
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var Employees = await employeeService.GetAllAsync();
            if (Employees == null) return NotFound();
            return Ok(Employees);
        }
        [HttpGet("PaginatedEmployees")]
        public async Task<ActionResult> GetPaginatedEmployees(int pageSize=10, int pageNumber = 1)
        {
            var Employees = await employeeService.PaginatedEmployeesAsync(pageSize, pageNumber);
            if (Employees == null) return NotFound();
            return Ok(Employees);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var Employee = await employeeService.GetByIdAsync(id);
            if (Employee == null) return NotFound();
            return Ok(Employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(AddEmployeeDTO employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
           var result=  await employeeService.AddEmployeeAsync(employee);
            if (!result.Success)
            {
                return BadRequest(new
                {
                    error = "Failed to create employee",
                    details = result.Errors
                });
            }
            return Ok( new
            {
                massage = "Employee added successfully",
                statusCode = 200
            });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateEmployee(int id , EditEmployeeDTO employeeDTO)
        {
            if(employeeDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await employeeService.UpdateEmployeeAsync(id, employeeDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (id == 0) return BadRequest();
            await employeeService.DeleteEmployeeAsync(id);
            return Ok(new
            {
                massage = "Employee Deleted Successfully",
                StatusCode = 200,
            });
        }
    }
}
