using Clinica.Domain.Entities;

namespace Clinica.Domain.Interfaces
{
    public interface IUserAppointmentRepository
    {
        Task<int> CreateAsync(UserAppointment request);
        Task<UserAppointment?> GetByIdAsync(int id);
        Task<IEnumerable<UserAppointment?>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UserAppointment request);
    }
}
