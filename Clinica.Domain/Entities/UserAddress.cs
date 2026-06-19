namespace Clinica.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
