using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAccessApp.Interface;
using UserAccessApp.Models;

namespace UserAccessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User model)
        {
            var response = _authService.GenerateToken(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
