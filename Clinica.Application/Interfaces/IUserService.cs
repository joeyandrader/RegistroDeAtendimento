using Clinica.Application.Dto.UserDto;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUserDto?> GetByIdAsync(int id);
        Task<IEnumerable<ResponseUserDto?>> GetAllAsync();
        /// <summary>
        /// Poderia também colocar para retornar int Id do usuario criado ou o proprio usuario!
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> CreateAsync(CreateUserDto request);
        Task<bool> UpdateAsync(UpdateUserDto request);
        Task<bool> DeleteAsync(int id);
    }
}
