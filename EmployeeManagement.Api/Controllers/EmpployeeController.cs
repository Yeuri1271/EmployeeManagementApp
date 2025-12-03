using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpployeeController : ControllerBase
    {

        private readonly EmployeeService _employeeService;

        public EmpployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll(CancellationToken cancellation = default)
        {
            var emplyees = await _employeeService.GetAllAsync(cancellation);

            return Ok(emplyees);
        }

        // GET: api/employees/{id}
        [HttpGet("(id:guid)")]
        public async Task<ActionResult<EmployeeDto>> GetById([FromQuery] Guid id, CancellationToken cancellation = default)
        {
            var empployee = await _employeeService.GetByIdAsync(id, cancellation);

            return Ok(empployee);
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeRequestDto employeeRequestDto, CancellationToken cancellation = default)
        {
            var response = await _employeeService.CreateAsync(employeeRequestDto, cancellation);

            return CreatedAtAction(nameof(GetById), new { response.Id }, response);
        }


        // PUT: api/employees/{id}
        [HttpPut("(id:guid)")]
        public async Task<ActionResult<bool>> Update([FromQuery] Guid id, [FromBody] UpdateEmployeeRequestDto employeeRequest, CancellationToken cancellation = default)
        {
            var response = await _employeeService.UpdateAsync(id, employeeRequest, cancellation);

            if (!response)
                return NotFound();

            return NoContent();
        }

        //DELETE: api/employee
        [HttpDelete("(id:guid)")]
        public async Task<ActionResult<bool>> Delete([FromQuery] Guid id, CancellationToken cancellation = default)
        {
            var response = await _employeeService.DeleteAsync(id, cancellation);

            if (!response)
                return NotFound();

            return NoContent();
        }
    }
}
