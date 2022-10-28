using EDO.Models.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<Guid> RegisterUser(UserRegistration userRegistration)
        {
            return Guid.NewGuid();
        }
    }
}
