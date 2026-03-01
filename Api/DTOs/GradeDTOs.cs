namespace OgrenciBilgiSistemiProject.DTOs;

public class GradeResponseDto 
{
    public int Id { get; set; }
    public int StudentCourseOfferingId { get; set; }
    public decimal Midterm { get; set; }
    public decimal Final { get; set; }
    public decimal Average { get; set; }
    public string LetterGrade { get; set; }
    public bool IsDeleted { get; set; }
}

public class GradeCreateDto
{
    public int StudentCourseOfferingId { get; set; }
    public decimal Midterm { get; set; }
    public decimal Final { get; set; }
    public decimal Average { get; set; }
    public string LetterGrade { get; set; } = string.Empty;
}