using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] Pagination pagination)
        {
            return Ok(await _userService.GetUsers(name, pagination.Limit, pagination.Skip));
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid userId)
        {
            return Ok(await _userService.GetUser(userId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}