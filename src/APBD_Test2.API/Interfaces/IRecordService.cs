using WebApplication1.DTOs;

namespace WebApplication1.Interfaces;

public interface IRecordService
{
    public Task<List<RecordResponseDTO>> GetAllRecords(GetRecordDTO? request);
    public Task<Record> InsertRecord(InsertRecordDTO request);
}