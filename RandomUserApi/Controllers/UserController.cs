using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomUserApi.Domain;
using RandomUserApi.Service;

namespace RandomUserApi.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly Pagination _defaultPagination;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
            _defaultPagination = new Pagination() {Limit = 20, Skip = 0};
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] Pagination pagination)
        {
            pagination ??= new Pagination();
            return Ok(await _userService.GetUsers(pagination.Limit, _defaultPagination.Skip, name));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            return Ok(await _userService.GetUser(userId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}