using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos;

namespace TPL.Servicies.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUser(UserCreateDto userDto);
        Task<List<UserResponseDto>> GetAllUsers(string token);
        Task<Guid> DeleteUser(Guid id);
        Task<UserResponseDto> UpdateUser(UserUpdateDto dto, Guid id);
        Task<UserAuthenticateResponseDto> Authenticate(UserAuthenticateDto model);
        Task<UserResponseDto> GetById(Guid id);
        Task<UserResponseDto> ResetUserPassword(string newPassword, string email);

    }

}
