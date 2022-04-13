using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos;
using TPL.Data.Entities;
using TPL.Data.Enums;
using TPL.Data.ExceptionTypes;
using TPL.Data.Validations;
using TPL.Repository.Interfaces;
using TPL.Servicies.Interfaces;

namespace TPL.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        //private readonly IConfigurationService

        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }
        public async Task<UserResponseDto> CreateUser(UserCreateDto userDto)
        {
            if (await userRepository.GetByEmail(userDto.Email) != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.Conflict, "This email is already in use");
            }
            var validator = new UserValidator();
            var validatedUser = validator.Validate(userDto);
            if(validatedUser.IsValid == true)
            {
                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Role = UserRole.Client,
                    Address = userDto.Address,
                    Surname = userDto.Surname

                };

                var addedUser = await userRepository.InsertAsync(user);

                var result = new UserResponseDto
                {
                    Id = addedUser.Id,
                    Name = addedUser.Name,
                    Email = addedUser.Email,
                    //Password = addedUser.Password,
                    Address = addedUser.Address,
                    Surname = addedUser.Surname,
                    Role = addedUser.Role,
                    CreatedAt = addedUser.CreatedAt,
                    CreatedBy = addedUser.CreatedBy
                };

                return result;
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<List<UserResponseDto>> GetAllUsers(string token)
        {
            var userr = await GetUserFromToken(token.Split(" ").Last());
            if (userr.Role == UserRole.Admin)
            {


                //var userr = await GetUserFromToken(token.Split(" ").Last());
                List<UserResponseDto> response = new List<UserResponseDto>();
                var users = await userRepository.GetAllUsersAsync();
                foreach (User user in users)
                {
                    var mappedUser = mapper.Map<UserResponseDto>(user);
                    response.Add(mappedUser);
                }

                return response;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            var deletedUser = await userRepository.DeleteAsync(id);

            return deletedUser;
        }

        public async Task<UserResponseDto> GetById(Guid id)
        {

            var result = await userRepository.GetByIdAsync(id);

            return mapper.Map<UserResponseDto>(result);

        }

        public async Task<UserResponseDto> UpdateUser(UserUpdateDto dto, Guid id)
        {
            User user = await userRepository.GetByIdAsync(id);
            var userMapped = mapper.Map<UserUpdateDto, User>(dto, user); 
            var updatedUser = await userRepository.UpdateAsync(userMapped);
            var mappedUser = mapper.Map<UserResponseDto>(updatedUser);
            return mappedUser;
        }

        public async Task<UserResponseDto> ResetUserPassword(string newPassword, string email)
        {
            User user = await userRepository.GetByEmail(email);
            if(user == null || user.Password == newPassword)
            {
                throw new NotImplementedException();
            }
            //var userMapped = mapper.Map<UserUpdateDto, User>(dto, user); 
            user.Password = newPassword;
            var updatedUser = await userRepository.UpdateAsync(user);
            var mappedUser = mapper.Map<UserResponseDto>(updatedUser);
            return mappedUser;
        }

        public async Task<UserAuthenticateResponseDto> Authenticate(UserAuthenticateDto model)
        {
            List<User> Users = await userRepository.GetAllUsersAsync();
            //UserAuthenticateResponseModel response = new UserAuthenticateResponseModel();
            UserAuthenticateResponseDto response = mapper.Map<UserAuthenticateResponseDto>(model);

            if (!Users.Any(u => u.Email == model.Email))
            {
                response.Result = "E-mail address is not registered.";
                return response;
            }

            User selectedUser = Users.First(u => u.Email == model.Email);
            if (selectedUser.Password != model.Password)
            {
                response.Result = "Incorrect password.";
                return response;
            }

            string token = await GenerateJwtToken(selectedUser);
            response.Token = token;

            response.Id = selectedUser.Id;
            response.Role = selectedUser.Role;
            response.Result = "Ok";
            return response;
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("email", user.Email), new Claim("role", user.Role.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            string id = jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value;
            string role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;
            User user = await userRepository.GetByIdAsync(new Guid(id));
            return user;
        }

    }
}
