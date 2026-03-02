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
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(AppDbContext context, IMapper mapper) 
        { 
            _context = context; 
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.Students
                .Include(s => s.User)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    StudentNumber = s.StudentNumber,
                    Email = s.User.Email,
                    DepartmentId = s.DepartmentId,
                    IsDeleted = !s.IsActive 
                }).ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _context.Students
                .Include(s => s.User)
                .Where(s => s.Id == id)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    StudentNumber = s.StudentNumber,
                    Email = s.User.Email,
                    DepartmentId = s.DepartmentId,
                    IsDeleted = !s.IsActive
                }).FirstOrDefaultAsync();

            if (student == null) return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                StudentNumber = dto.StudentNumber,
                UserId = dto.UserId,
                DepartmentId = dto.DepartmentId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok("Student created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound("Student not found");

            student.StudentNumber = dto.StudentNumber;
            student.DepartmentId = dto.DepartmentId;
            student.UpdatedAt = DateTime.UtcNow; 

            await _context.SaveChangesAsync();
            return Ok("Student updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound("Student not found");

            student.IsActive = false;
            student.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok("Student soft-deleted successfully");
        }
    }
}