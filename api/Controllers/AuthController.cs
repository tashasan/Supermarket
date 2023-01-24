using Business.AuthBusiness;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusinessService _authBusiness;
        public AuthController(IAuthBusinessService authBusiness)
        {
            _authBusiness = authBusiness;
        }
        [HttpPost]
        [Route("Login/{username}/{password}")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var loginUser = _authBusiness.Login(username, password);
            if (!loginUser.IsCompletedSuccessfully)
                return BadRequest("Login Failed");

            return Ok(await loginUser);
        }
    }
}
