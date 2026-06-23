using AutoMapper;
using Clinica.Application.Dto.UserDto;
using Clinica.Application.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;

namespace Clinica.Application.Services
{
    public class UserService(
        IUserRepository _repository,
        IAddressRepository _addressRepository,
        IMapper _mapper) : IUserService
    {

        public async Task<int> CreateAsync(CreateUserDto request)
        {
            var findUserByCpf = await _repository.FindByCpf(request.Cpf);
            if (findUserByCpf)
                throw new ApplicationException("Ja existe um usuario com esse CPF cadastrado!");

            var userId = await _repository.CreateAsync(_mapper.Map<User>(request));

            //Cria o endereço
            var address = _mapper.Map<UserAddress>(request.Address);
            address.UserId = userId;
            await _addressRepository.CreateAsync(address);

            return userId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResponseUserDto?>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ResponseUserDto?>>(await _repository.GetAllAsync());
        }

        public async Task<ResponseUserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null)
                throw new Exception("Usuario não encontrado!");
            return _mapper.Map<ResponseUserDto?>(user);
        }

        public async Task<bool> UpdateAsync(UpdateUserDto request)
        {
            return await _repository.UpdateAsync(_mapper.Map<User>(request));
        }
    }
}
