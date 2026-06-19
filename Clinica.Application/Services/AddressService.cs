using AutoMapper;
using Clinica.Application.Dto.Address;
using Clinica.Application.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;

namespace Clinica.Application.Services
{
    public class AddressService(
        IAddressRepository _addressRepository,
        IMapper _mapper) : IAddressService
    {
        public async Task CreateAsync(CreateAddressDto request)
        {
            var map = _mapper.Map<UserAddress>(request);
            await _addressRepository.CreateAsync(map);
        }

        public async Task<ResponseAddressDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ResponseAddressDto?>(await _addressRepository.GetByIdAsync(id));
        }

        public async Task<bool> UpdateAsync(UpdateAddressDto request)
        {
            return await _addressRepository.UpdateAsync(_mapper.Map<UserAddress>(request));
        }
    }
}
