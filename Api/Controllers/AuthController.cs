using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemiProject.DTOs;
using OgrenciBilgiSistemiProject.Services;

namespace OgrenciBilgiSistemiProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _authService.Login(request);

            if (result == null)
                return Unauthorized(new { message = "Email veya şifre hatalı" });

            return Ok(result);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("adminpanel")]
        public IActionResult AdminPanel()
        {
            return Ok("Sadece Teacher rolü erişebilir.");
        }
    }
}