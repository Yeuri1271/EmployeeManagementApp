using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;  
        }

        //POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequest, CancellationToken cancellation = default)
        {
            var result = await _authService.LoginAsync(loginRequest, cancellation);

            if(result == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            return Ok(result);
        }
    }
}
