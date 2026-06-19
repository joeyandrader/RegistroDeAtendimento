using Clinica.Application.Dto.Address;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interfaces
{
    public interface IAddressService
    {
        Task<ResponseAddressDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateAddressDto request);
        Task<bool> UpdateAsync(UpdateAddressDto request);
    }
}
