using Clinica.Domain.Entities;

namespace Clinica.Domain.Interfaces;

public interface IAddressRepository
{
    Task<UserAddress?> GetByIdAsync(int id);
    Task CreateAsync(UserAddress request);
    Task<bool> UpdateAsync(UserAddress request);
}
