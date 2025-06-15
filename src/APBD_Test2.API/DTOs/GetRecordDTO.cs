using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class GetRecordDTO
{
    public int? LanguageId { get; set; }
    public int? TaskId { get; set; }
    [RegularExpression(@"^\d{2}\/\d{2}\/\d{4} \d{2}:\d{2}:\d{2}$", 
        ErrorMessage = "Invalid format. Please use mm/dd/yyyy HH:mm:ss")]
    public string? Created { get; set; }
    
    public DateTime ParseDate()
    {
        var parts = Created.Split(' ');
        var dateParts = parts[0].Split('/');
        var day = int.Parse(dateParts[1]);
        var month = int.Parse(dateParts[0]);
        var year = int.Parse(dateParts[2]);
        var timeParts = parts[1].Split(':');
        var hour = int.Parse(timeParts[0]);
        var minute = int.Parse(timeParts[1]);
        var second = int.Parse(timeParts[2]);
        return new DateTime(year, month, day, hour, minute, second);
    }
}