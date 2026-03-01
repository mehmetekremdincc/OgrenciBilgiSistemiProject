namespace OgrenciBilgiSistemiProject.DTOs;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string StudentNumber { get; set; }
    public string Email { get; set; } // User üzerinden gelecek
    public string FullName { get; set; } // Opsiyonel: User'dan birleştirilecek
    public int DepartmentId { get; set; }
    public bool IsDeleted { get; set; } // BaseModel'den gelen durum
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