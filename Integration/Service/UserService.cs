﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Repository;
using Domain;
using Domain.Model;

namespace Integration.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(string name, int? limit, int? skip);
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

        public async Task<IEnumerable<User>> GetUsers(string name, int? limit, int? skip)
        {
            limit ??= 20;
            skip ??= 0;
            var entities = await _userRepository.GetUsers(limit.Value, skip.Value, name);
            return Mapper.Map<IEnumerable<User>>(entities);
        }

        public async Task<User> GetUser(Guid userId)
        {
            if (userId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(userId));
            var entity = await _userRepository.GetUser(userId);
            return Mapper.Map<User>(entity);
        }

        public async Task UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var entity = Mapper.Map<UserEntity>(user);
            await _userRepository.UpdateUser(entity);
        }

        public async Task DeleteUser(Guid userId)
        {
            if (userId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(userId));
            try
            {
                await _userRepository.DeleteUser(userId);
            }
            catch (ArgumentNullException)
            {
            }
        }
    }
}