using Clinica.Application.Dto.UserDto;
using Clinica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController(
        IUserService _userService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            return Ok(await _userService.CreateAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
