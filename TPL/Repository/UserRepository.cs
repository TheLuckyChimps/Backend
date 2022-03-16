using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;
using TPL.Database;
using TPL.Repository.Interfaces;

namespace TPL.Repository
{
    public class UserRepository : IUserRepository
    {
            private readonly WebApiContext context;
            private readonly DbSet<User> dbSet;
            public UserRepository(WebApiContext context)
            {
                this.context = context;
                dbSet = context.Set<User>();
            }

        public async Task<User> GetByEmail(string email)
        {
            var user = await dbSet.Where(e => e.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return users;
        }

        public async Task<User> InsertAsync(User user)
            {
                user.OnCreate(user.Id);
                var addedUser = (await dbSet.AddAsync(user)).Entity;
                await context.SaveChangesAsync();

                return addedUser;
            }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var user = await dbSet.FindAsync(id);
            user.SoftDelete();
            await context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User> UpdateAsync(User userUpdate)
        {
            dbSet.Update(userUpdate);
            await context.SaveChangesAsync();

            return userUpdate;
        }
    }
}
