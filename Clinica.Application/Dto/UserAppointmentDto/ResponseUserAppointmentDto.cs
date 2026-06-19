using Clinica.Domain.Entities;
using Clinica.Domain.Enums;
namespace Clinica.Application.Dto.UserAppointmentDto
{
    public record ResponseUserAppointmentDto(
        int Id,
        DateTime AppointmentDate,
        string Description,
        StatusEnum status,
        int UserId,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        User user);
}
