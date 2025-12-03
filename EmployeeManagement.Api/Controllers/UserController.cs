using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;  
        }

        //GET: api/users
        [HttpGet("users")]
        public async Task<ActionResult<List<UserAppDto>>> GetUsers(CancellationToken cancellation = default)
        {
            var users = await _authService.GetUsersAsync(cancellation);

            return Ok(users);
        }
    }
}
