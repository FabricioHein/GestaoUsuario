// Controllers/AuthController.cs
using GestaoUsuario.Models;
using GestaoUsuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _authService.Register(user);
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var token = await _authService.Login(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
