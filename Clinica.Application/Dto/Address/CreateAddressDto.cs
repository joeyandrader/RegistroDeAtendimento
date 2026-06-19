namespace Clinica.Application.Dto.Address
{
    public record CreateAddressDto(
        string AddressLine1,
        string AddressLine2,
        string Neighborhood,
        string City,
        string Country,
        string State,
        string ZipCode,
        int UserId
        );
}
