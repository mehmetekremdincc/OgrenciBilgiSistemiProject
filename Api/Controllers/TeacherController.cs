using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.DTOs;
using AutoMapper;

namespace OgrenciBilgiSistemiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TeacherController(AppDbContext context, IMapper mapper) 
        { 
            _context = context; 
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _context.Teachers
                .Include(t => t.User)
                .Select(t => new TeacherResponseDto
                {
                    Id = t.Id,
                    Email = t.User.Email,
                    DepartmentId = t.DepartmentId,
                    IsDeleted = !t.IsActive // Aktif değilse silinmiş (DTO ile uyum)
                }).ToListAsync();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDto dto)
        {
            var teacher = new Teacher
            {
                UserId = dto.UserId,
                DepartmentId = dto.DepartmentId,
                IsActive = true, // Yeni kayıt her zaman aktiftir
                CreatedAt = DateTime.UtcNow
            };
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return Ok("Teacher created successfully");
        }
    }
}