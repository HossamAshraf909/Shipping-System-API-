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



        [HttpPost]
        public async Task<ActionResult> AddEmployee(AddEmployeeDTO employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await employeeService.AddEmployeeAsync(employee);
            return Ok( new
            {
                massage = "Employee added successfully",
                statusCode = 200
            });
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateEmployee(int id , AddEmployeeDTO employeeDTO)
        {
            if(employeeDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await employeeService.UpdateEmployeeAsync(id, employeeDTO);
            return Ok();
        }


    }
}
