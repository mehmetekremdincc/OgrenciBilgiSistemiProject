namespace OgrenciBilgiSistemiProject.DTOs;

public class TeacherResponseDto
{
    public int Id { get; set; }
    public string Email { get; set; } // User üzerinden
    public string FullName { get; set; }
    public int DepartmentId { get; set; }
    public bool IsDeleted { get; set; }
}

public class TeacherCreateDto
{
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
}