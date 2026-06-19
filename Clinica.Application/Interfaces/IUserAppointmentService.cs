using Clinica.Application.Dto.UserAppointmentDto;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interfaces
{
    public interface IUserAppointmentService
    {
        Task<int> CreateAsync(CreateUserAppointmentDto request);
        Task<ResponseUserAppointmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<ResponseUserAppointmentDto?>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UpdateUserAppointmentDto request);
    }
}
