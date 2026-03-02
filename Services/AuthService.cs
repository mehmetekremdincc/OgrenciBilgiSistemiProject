using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.DTOs;
using OgrenciBilgiSistemiProject.Models;
using System.Linq;

namespace OgrenciBilgiSistemiProject.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public LoginResponse Login(LoginRequest request)
        {
          
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result != PasswordVerificationResult.Success) return null;

            return new LoginResponse
            {
                Token = null,                     
                Role = user.Role?.Name ?? "Undefined",
                Username = user.Email             
            };
        }




    }
}