using Clinica.Domain.Entities;

namespace Clinica.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User?>> GetAllAsync();
    Task<int> CreateAsync(User request);
    Task<bool> UpdateAsync(User request);
    Task<bool> DeleteAsync(int id);
}
