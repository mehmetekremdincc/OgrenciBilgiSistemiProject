using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.DTOs;

namespace OgrenciBilgiSistemiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GradeController(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> AddGrade(GradeCreateDto dto)
        {
            var grade = new Grade
            {
                StudentCourseOfferingId = dto.StudentCourseOfferingId,
                Midterm = dto.Midterm,
                Final = dto.Final,
                Average = dto.Average,
                LetterGrade = dto.LetterGrade,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return Ok("Grade added");
        }
    }
}