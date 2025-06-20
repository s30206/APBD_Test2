﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class TaskDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(2000)]
    public string Description { get; set; }
}