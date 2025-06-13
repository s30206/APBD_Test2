using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Services;

public class RecordService : IRecordService
{
    private readonly RecordManiaContext _context;

    public RecordService(RecordManiaContext context)
    {
        _context = context;
    }
    
    public async Task<Record> InsertRecord(InsertRecordDTO request)
    {
        var language = await _context.Languages.FindAsync(request.LanguageId);
        if (language == null)
            throw new KeyNotFoundException("Language with given id not found");
        
        var student = await _context.Students.FindAsync(request.StudentId);
        if (student == null)
            throw new KeyNotFoundException("Student with given id not found");

        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Name == request.Task.Name);
        if (task == null)
        {
            var newTask = new Task()
            {
                Name = request.Task.Name,
                Descrition = request.Task.Description,
            };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
        }
        
        task = await _context.Tasks.FirstOrDefaultAsync(t => t.Name == request.Task.Name);

        var record = new Record()
        {
            StudentId = student.Id,
            LanguageId = language.Id,
            TaskId = task.Id,
            ExecutionTime = request.ExecutionTime,
            CreatedAt = request.Created
        };
        
        _context.Records.Add(record);
        await _context.SaveChangesAsync();
        return record;
    }
}