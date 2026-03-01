using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.DTOs;

namespace OgrenciBilgiSistemiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseOfferingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentCourseOfferingController(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> Enroll(StudentCourseOfferingCreateDto dto)
        {
            var enrollment = new StudentCourseOffering
            {
                StudentId = dto.StudentId,
                CourseOfferingId = dto.CourseOfferingId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _context.StudentCourseOfferings.Add(enrollment);
            await _context.SaveChangesAsync();
            return Ok("Student enrolled to course");
        }
    }
}