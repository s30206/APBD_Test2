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

    public async Task<List<RecordResponseDTO>> GetAllRecords(GetRecordDTO? request)
    {
        var records = _context.Records
            .Include(r => r.Task)
            .Include(r => r.Student)
            .Include(r => r.Language)
            .OrderByDescending(r => r.CreatedAt)
            .ThenBy(r => r.Student.LastName).Select(r => new RecordResponseDTO
            {
                Id = r.Id,
                Language = new LanguageDTO
                {
                    Id = r.Language.Id,
                    Name = r.Language.Name
                },
                Task = new TaskDTO
                {
                    Id = r.Task.Id,
                    Name = r.Task.Name,
                    Description = r.Task.Descrition
                },
                Student = new StudentDTO()
                {
                    Id = r.Student.Id,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Email = r.Student.Email,
                },
                ExecutionTime = r.ExecutionTime,
                Created = r.CreatedAt
            });

        if (request != null)
        {
            if (request.LanguageId != null)
            {
                var result = new List<RecordResponseDTO>();
                foreach (var record in records)
                {
                    if (record.Language.Id == request.LanguageId)
                        result.Add(record);
                }

                return result;
            }

            if (request.Created != null)
            {
                var result = new List<RecordResponseDTO>();
                foreach (var record in records)
                {
                    if (record.Created == request.Created)
                        result.Add(record);
                }

                return result;
            }
        }

        return records.ToList();
    }

    public async Task<Record> InsertRecord(InsertRecordDTO request)
    {
        var language = await _context.Languages.FindAsync(request.LanguageId);
        if (language == null)
            throw new KeyNotFoundException("Language with given id not found");
        
        var student = await _context.Students.FindAsync(request.StudentId);
        if (student == null)
            throw new KeyNotFoundException("Student with given id not found");

        var task = await _context.Tasks.FindAsync(request.Task.Id);
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