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
        [HttpPost]
        public IActionResult Authenticate(Login model)
        {
            var response = _authService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
