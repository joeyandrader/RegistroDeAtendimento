using Clinica.Domain.Enums;

namespace Clinica.Domain.Entities
{
    public class UserAppointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
