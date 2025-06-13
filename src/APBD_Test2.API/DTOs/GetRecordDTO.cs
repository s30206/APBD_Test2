namespace WebApplication1.DTOs;

public class GetRecordDTO
{
    public int? LanguageId { get; set; }
    public int? StudentId { get; set; }
    public int? TaskId { get; set; }
    public long? ExecutionTime { get; set; }
    public DateTime? Created { get; set; }
}