using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAllUsersAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<User> UpdateAsync(User userUpdate);
        Task<User> GetByIdAsync(Guid id);
    }
}
