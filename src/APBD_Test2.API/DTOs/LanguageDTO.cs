using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class LanguageDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}