using Clinica.Application.Dto.Address;
using Clinica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController(IAddressService _addressService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAddressDto request)
        {
            await _addressService.CreateAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _addressService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressDto request)
        {
            var result = await _addressService.UpdateAsync(request);
            return Ok(result);
        }
    }
}
