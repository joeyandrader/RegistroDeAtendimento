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
            try
            {
                return Ok(await _userService.CreateAsync(request));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto request)
        {
            var result = await _userService.UpdateAsync(request);
            return Ok(result);
        }
    }
}
