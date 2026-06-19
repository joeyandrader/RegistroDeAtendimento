using Clinica.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        public SexEnum Sex { get; set; }

        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public UserAddress Address { get; set; }

        public IEnumerable<UserAppointment> UserAppointment { get; set; } = new List<UserAppointment>();
    }
}
