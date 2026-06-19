using Clinica.Domain.Entities;
using Clinica.Domain.Enums;

namespace Clinica.Application.Dto.UserDto;

public record ResponseUserDto(
    int Id,
    string Name,
    DateTime DateOfBirth,
    string Cpf,
    SexEnum Sex,
    StatusEnum Status,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    UserAddress Address
    );
