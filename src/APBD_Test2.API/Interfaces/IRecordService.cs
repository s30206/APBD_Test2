using WebApplication1.DTOs;

namespace WebApplication1.Interfaces;

public interface IRecordService
{
    public Task<Record> InsertRecord(InsertRecordDTO request);
}