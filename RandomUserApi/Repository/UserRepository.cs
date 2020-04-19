using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data;
using RandomUserApi.Data.Entities;

namespace RandomUserApi.Repository
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetUsers(int limit, int skip, string name);
        Task<UserEntity> GetUser(Guid userId);
        Task UpdateUser(UserEntity user);
        Task DeleteUser(Guid userId);
        Task CreateUsers(IEnumerable<UserEntity> users);
    }

    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public Task<List<UserEntity>> GetUsers(int limit, int skip, string name)
        {
            return _context.UserEntities.Where(u => u.FirstName.Contains(name) || u.LastName.Contains(name))
                .ToListAsync();
        }

        public Task<UserEntity> GetUser(Guid userId)
        {
            return _context.UserEntities.FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public async Task UpdateUser(UserEntity user)
        {
            _context.UserEntities.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid userId)
        {
            var toDelete = await _context.UserEntities.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            _context.UserEntities.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUsers(IEnumerable<UserEntity> users)
        {
            await _context.UserEntities.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
    }
}