namespace Clinica.Application.Dto.Address
{
    public record ResponseAddressDto(
        int Id,
        string AddressLine1,
        string AddressLine2,
        string Neighborhood,
        string City,
        string State,
        string ZipCode,
        int UserId,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
