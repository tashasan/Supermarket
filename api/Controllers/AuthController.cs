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
            var loginUser = _authBusiness.Login(username, password).Result;
            if (loginUser == null)
                return BadRequest("Login Failed");

            return Ok(loginUser);
        }
    }
}
