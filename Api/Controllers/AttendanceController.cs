using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemiProject.Data;
using OgrenciBilgiSistemiProject.Models;
using OgrenciBilgiSistemiProject.DTOs;

namespace OgrenciBilgiSistemiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AttendanceController(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> AddAttendance(AttendanceCreateDto dto)
        {
            var attendance = new Attendance
            {
                StudentCourseOfferingId = dto.StudentCourseOfferingId,
                Date = dto.Date,
                Status = dto.Status,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return Ok("Attendance recorded");
        }
    }
}