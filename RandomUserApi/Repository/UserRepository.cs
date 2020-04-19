using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RandomUserApi.Domain;
using RandomUserApi.Entities;

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
        public Task<IEnumerable<UserEntity>> GetUsers(int limit, int skip, string name)
        {
            return new Task<IEnumerable<UserEntity>>(() => new List<UserEntity>()
                {new UserEntity(), new UserEntity(), new UserEntity(), new UserEntity()});
        }

        public Task<UserEntity> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}