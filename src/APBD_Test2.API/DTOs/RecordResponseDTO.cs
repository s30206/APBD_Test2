namespace WebApplication1.DTOs;

public class RecordResponseDTO
{
    public int Id { get; set; }
    public LanguageDTO Language { get; set; }
    public TaskDTO Task { get; set; }
    public StudentDTO Student { get; set; }
    public long ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}