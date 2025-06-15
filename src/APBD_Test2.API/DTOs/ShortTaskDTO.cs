using Microsoft.Build.Framework;

namespace WebApplication1.DTOs;

public class ShortTaskDTO
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}