using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoMapper;
using Moq;
using RandomUserApi.Data.Entities;
using RandomUserApi.Data.Repository;
using RandomUserApi.Domain;
using RandomUserApi.Service;
using Xunit;

namespace RandomUserApi.UnitTests
{
    public class TestUserService : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public TestUserService()
        {
            MapperConfiguration.Init();
            _mock = AutoMock.GetLoose();
            _userRepository = _mock.Mock<IUserRepository>().Object;
            _userService = new UserService(_userRepository);

        }

        public void Dispose()
        {
            _mock.Dispose();
            Mapper.Reset();
        }

        [Fact]
        public async Task GetUsers_WhenNullLimit_DefaultTo20()
        {
            var users = await _userService.GetUsers(null, 20, 0);
            _mock.Mock<IUserRepository>().Verify(ur => ur.GetUsers(20, 0, null), Times.Once);
        }

        [Fact]
        public async Task GetUsers_WhenNullSkip_DefaultTo0()
        {
            var users = await _userService.GetUsers(null, null, null);
            _mock.Mock<IUserRepository>().Verify(ur => ur.GetUsers(20, 0, null), Times.Once);
        }

        [Fact]
        public async Task GetUsers_WhenNullName_CallWithNull()
        {
            var users = await _userService.GetUsers(null, 20, 0);
            _mock.Mock<IUserRepository>().Verify(ur => ur.GetUsers(20, 0, null), Times.Once);
        }

        [Fact]
        public async Task GetUser_ValidUserId_ReturnUser()
        {
            var userId = Guid.NewGuid();
            var user = await _userService.GetUser(userId);
            _mock.Mock<IUserRepository>().Verify(ur => ur.GetUser(userId), Times.Once);
        }

        [Fact]
        public async Task UpdateUser_NullUser_ThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _userService.UpdateUser(null));
            Assert.NotStrictEqual(new ArgumentNullException(), ex);
            _mock.Mock<IUserRepository>().Verify(ur => ur.UpdateUser(null), Times.Never);
        }

        [Fact]
        public async Task UpdateUser_ValidUser_ReturnVoid()
        {
            var user = new User();
            await _userService.UpdateUser(user);
            _mock.Mock<IUserRepository>().Verify(ur => ur.UpdateUser(It.IsAny<UserEntity>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_EmptyUserId_ThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _userService.DeleteUser(Guid.Empty));
            Assert.NotStrictEqual(new ArgumentNullException(), ex);
            _mock.Mock<IUserRepository>().Verify(ur => ur.DeleteUser(Guid.Empty), Times.Never);
        }

        [Fact]
        public async Task DeleteUser_ValidUserId_ReturnVoid()
        {
            var userId = Guid.NewGuid();
            await _userService.DeleteUser(userId);
            _mock.Mock<IUserRepository>().Verify(ur => ur.DeleteUser(userId), Times.Once);
        }
    }
}