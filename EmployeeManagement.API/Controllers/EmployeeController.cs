using EmployeeManagement.Application.Commands.Employees.CreateEmployee;
using EmployeeManagement.Application.Commands.Employees.DeleteEmployee;
using EmployeeManagement.Application.Commands.Employees.UpdateEmployee;
using EmployeeManagement.Application.Queries;
using EmployeeManagement.Application.Queries.GetAllEmployee;
using EmployeeManagement.Application.Queries.GetEmployeeById;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagement.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        //private readonly CreateEmployeeCommandHandler _createEmployeeCommnadHandler;

        private readonly IMediator _mediator;

        public EmployeeController(IEmployeeService employeeService,IMediator mediator)
        {
            _employeeService = employeeService;
            _mediator = mediator;
        }
        // [Authorize(Roles ="Admin, HR, Manager")]
        [Authorize(policy:"CanViewEmployees")]
        [HttpGet("emp")]

        public async Task<ActionResult<List<EmployeeDto>>> GetEmployee()
        {
            var res = await _mediator.Send(new GetEmployeeQuery());

            if (res == null)
            {
                return BadRequest("Employee not found in database");
            }

            return Ok(res);


        }
        // [Authorize (Roles="Admin, HR, Manager")]
        [Authorize(policy:"CanViewEmployees")]
        [HttpGet("id")]
        public async Task<IActionResult> GetEmpById([FromQuery] int id)
        {
            var res = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            if (res == null)
            {
                return BadRequest("Employee not found by this id ");
            }

            return Ok(res);

        }
        // [Authorize(Roles = "Admin, HR")]
       [Authorize(policy:"CanCreateEmployees")]
        [HttpPost]
        public async Task<IActionResult> AddEmp(CreateEmployeeCommand emp)
        {
            var res = await _mediator.Send(emp);

            return Ok(res);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize(policy:"CanDeleteEmployees")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEmp(int id)
        {

            var deleted = await _mediator.Send(new DeleteEmployeeCommand { Id=id});

            if(!deleted)
            {
              return   NotFound($"Emp Not Found with this {id}");
            }

            return Ok("emp deleted");

        }

        [HttpPut  ("id")]
        public async Task<IActionResult> UpadateEmp(int id,
    UpdateEmployeeCommand emp)
        {
            emp.Id = id;

            var res = await _mediator.Send(emp);

            if (res == null)
            {
                return NotFound($"Employee not found with id {id}");
            }

            return Ok(res);


        }
    }
}