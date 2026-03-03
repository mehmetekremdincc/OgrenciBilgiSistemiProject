using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.DTOs;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.Services.Abstract;

namespace OgrenciBilgiSistemiProject.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            AppDbContext context,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public LoginResponse? Login(LoginRequest request)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null) return null;

            bool isValid = false;

            try
            {
                isValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            }
            catch
            {
                isValid = (user.PasswordHash == request.Password);
            }

            if (!isValid) return null;

            var token = _tokenService.CreateToken(user);

            return new LoginResponse
            {
                Username = user.Email,
                Role = user.Role?.Name ?? "User", 
                Token = token
            };
        }
    }
}