using Clinica.Application.Dto.UserAppointmentDto;
using Clinica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("api/v1/appointment")]
    public class AppointmentController(IUserAppointmentService _userAppointmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserAppointmentDto request)
        {
            try
            {
                return Ok(await _userAppointmentService.CreateAsync(request));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(await _userAppointmentService.GetByIdAsync(id));
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userAppointmentService.GetAllAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return Ok(await _userAppointmentService.DeleteAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserAppointmentDto request)
        {
            return Ok(await _userAppointmentService.UpdateAsync(request));
        }
    }
}
