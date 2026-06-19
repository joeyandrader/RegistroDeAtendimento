using Clinica.Application.Dto.Address;
using Clinica.Domain.Enums;

namespace Clinica.Application.Dto.UserDto;

public record CreateUserDto(
    string Name,
    DateTime DateOfBirth,
    string Cpf,
    SexEnum Sex,
    CreateAddressDto Address
    );
