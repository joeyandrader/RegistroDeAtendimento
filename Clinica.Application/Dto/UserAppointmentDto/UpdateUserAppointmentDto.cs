using Clinica.Domain.Enums;

namespace Clinica.Application.Dto.UserAppointmentDto
{
    public record UpdateUserAppointmentDto(
        DateTime AppointmentDate,
        string Description,
        StatusEnum status,
        int UserId);
}
