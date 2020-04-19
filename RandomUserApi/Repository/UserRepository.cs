using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RandomUserApi.Data.Entities;
using RandomUserApi.Domain;

namespace RandomUserApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsers(int limit, int skip, string name);
        Task<UserEntity> GetUser(Guid userId);
        Task UpdateUser(UserEntity user);
        Task DeleteUser(Guid userId);
    }

    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsers(int limit, int skip, string name)
        {
            var test = new List<UserEntity>()
                {new UserEntity(), new UserEntity(), new UserEntity(), new UserEntity()};

            return test;
        }

        public async Task<UserEntity> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}