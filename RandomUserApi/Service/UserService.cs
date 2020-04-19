using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RandomUserApi.Domain;
using RandomUserApi.Entities;
using RandomUserApi.Repository;

namespace RandomUserApi.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(int limit, int skip, string name);
        Task<User> GetUser(Guid userId);
        Task UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers(int limit, int skip, string name)
        {
            var entities = await _userRepository.GetUsers(limit, skip, name);
            return Mapper.Map<IEnumerable<User>>(entities);
        }

        public async Task<User> GetUser(Guid userId)
        {
            var entity = await _userRepository.GetUser(userId);
            return Mapper.Map<User>(entity);
        }

        public async Task UpdateUser(User user)
        {
            var entity = Mapper.Map<UserEntity>(user);
            await _userRepository.UpdateUser(entity);
        }

        public async Task DeleteUser(Guid userId)
        {
            await _userRepository.DeleteUser(userId);
        }
    }
}