using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.DTOs;
using OgrenciBilgiSistemiProject.Services.Abstract;

namespace OgrenciBilgiSistemiProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(ITokenService tokenService, IMapper mapper, AppDbContext context, IPasswordHasher passwordHasher)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users
      .Include(u => u.Role)
      .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
                return Unauthorized(new { message = "Email veya şifre hatalı" });

            var isValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isValid)
                return Unauthorized(new { message = "Email veya şifre hatalı" });

            var token = _tokenService.CreateToken(user);

            var response = new LoginResponse
            {
                Username = user.Email,
                Role = user.Role.Name,
                Token = token
            };
                
            return Ok(response);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("adminpanel")]
        public IActionResult AdminPanel()
        {
            return Ok("Sadece öğretmenler erişebilir.");
        }
    }
}