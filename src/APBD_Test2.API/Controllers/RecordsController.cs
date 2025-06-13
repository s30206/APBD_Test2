using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _service;

        public RecordsController(IRecordService service)
        {
            _service = service;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordResponseDTO>>> GetRecords(GetRecordDTO? request)
        {
            try
            {
                var result = await _service.GetAllRecords(request);
                return result.IsNullOrEmpty() ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(InsertRecordDTO request)
        {
            try
            {
                var result = await _service.InsertRecord(request);
                return Created("/api/languages/", result.Id);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
