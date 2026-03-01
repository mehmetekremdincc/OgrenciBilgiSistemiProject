using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.DTOs;

namespace OgrenciBilgiSistemiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DepartmentController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _context.Departments
                .Select(d => new DepartmentResponseDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    IsDeleted = !d.IsActive
                }).ToListAsync();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok("Department created");
        }
    }
}