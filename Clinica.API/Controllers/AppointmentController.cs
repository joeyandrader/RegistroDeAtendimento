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
            return Ok(await _userAppointmentService.CreateAsync(request));
        }
    }
}
