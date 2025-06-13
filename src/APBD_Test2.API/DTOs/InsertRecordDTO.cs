using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class InsertRecordDTO
{
    [Required]
    [Range(1, int.MaxValue)]
    public int LanguageId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int StudentId { get; set; }
    [Required]
    public TaskDTO Task { get; set; }
    [Required]
    public long ExecutionTime { get; set; }
    [Required]
    public DateTime Created { get; set; }
}