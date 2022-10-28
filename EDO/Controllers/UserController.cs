using EDO.Models.Inputs;
using EDO.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("{userGuid}")]
        public async Task<ActionResult<Guid>> UpdateUser([FromRoute] Guid userGuid, UserRegistration userRegistration)
        {
            await _userService.UpdateUser(userGuid, userRegistration);
            return Ok(userGuid);
        }
    }
}
