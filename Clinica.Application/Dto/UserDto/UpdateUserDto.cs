using Clinica.Domain.Enums;

namespace Clinica.Application.Dto.UserDto;

public record UpdateUserDto(
    int Id,
    string Name,
    DateTime DateOfBirth,
    string Cpf,
    SexEnum Sex,
    StatusEnum Status
    );
