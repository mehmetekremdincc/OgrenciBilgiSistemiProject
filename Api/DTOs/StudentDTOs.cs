namespace OgrenciBilgiSistemiProject.DTOs;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string StudentNumber { get; set; }
    public string Email { get; set; } 
    public string FullName { get; set; } 
    public int DepartmentId { get; set; }
    public bool IsDeleted { get; set; } 
}

public class StudentCreateDto
{
    public string StudentNumber { get; set; }
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
}

public class StudentUpdateDto
{
    public string StudentNumber { get; set; }
    public int DepartmentId { get; set; }
}