using EDO.Models.Inputs;
using EDO.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace EDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> RegisterUser(UserRegistration userRegistration)
        {
            return Ok(await _userService.RegisterUser(userRegistration));
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<ActionResult<Guid>> UpdateUser([FromRoute] Guid userId, UserRegistration userRegistration)
        {
            await _userService.UpdateUser(userId, userRegistration);
            return Ok(userId);
        }

        [HttpGet]
        public async Task<ActionResult<bool>> AuthoriseUser(string login, string password)
        {
            if (await _userService.AuthoriseUser(login, password))
                return Ok();
            return BadRequest();
        }
    }
}
