using AutoMapper;
using Clinica.Application.Dto.Address;
using Clinica.Application.Dto.UserAppointmentDto;
using Clinica.Application.Dto.UserDto;
using Clinica.Domain.Entities;

namespace Clinica.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //UserMapping request
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            //UserMapping Response
            CreateMap<User, ResponseUserDto>();

            //AddressMapping request
            CreateMap<CreateAddressDto, UserAddress>();
            CreateMap<UpdateAddressDto, UserAddress>();
            //AddressMapping Response
            CreateMap<UserAddress, ResponseAddressDto>();

            //UserAppointment request
            CreateMap<CreateUserAppointmentDto, UserAppointment>();
            CreateMap<UpdateUserAppointmentDto, UserAppointment>();
            //UserAppointment Response
            CreateMap<UserAppointment, ResponseUserAppointmentDto>();
        }
    }
}
