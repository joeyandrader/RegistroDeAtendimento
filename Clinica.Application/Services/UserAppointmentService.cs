using AutoMapper;
using Clinica.Application.Dto.UserAppointmentDto;
using Clinica.Application.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;

namespace Clinica.Application.Services
{
    public class UserAppointmentService
        (
        IUserAppointmentRepository _userAppointmentRepository,
        IMapper _mapper
        )
        : IUserAppointmentService
    {
        public async Task<int> CreateAsync(CreateUserAppointmentDto request)
        {
            var currentDate = DateTime.Now;
            var endDate = currentDate.Date.AddDays(1).AddTicks(-1);
            if (request.AppointmentDate < currentDate || request.AppointmentDate > endDate)
                throw new ApplicationException("Não é permitido criar o agendamento selecione uma data atual e a hora.");

            return await _userAppointmentRepository.CreateAsync(_mapper.Map<UserAppointment>(request));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userAppointmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResponseUserAppointmentDto?>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ResponseUserAppointmentDto?>>(await _userAppointmentRepository.GetAllAsync());
        }

        public async Task<ResponseUserAppointmentDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ResponseUserAppointmentDto?>(await _userAppointmentRepository.GetByIdAsync(id));
        }

        public async Task<bool> UpdateAsync(UpdateUserAppointmentDto request)
        {
            var currentDate = DateTime.Now;
            var endDate = currentDate.Date.AddDays(1).AddTicks(-1);
            if (request.AppointmentDate < currentDate || request.AppointmentDate > endDate)
                throw new ApplicationException("Não é permitido criar o agendamento selecione uma data atual e a hora.");
            return await _userAppointmentRepository.UpdateAsync(_mapper.Map<UserAppointment>(request));
        }
    }
}
