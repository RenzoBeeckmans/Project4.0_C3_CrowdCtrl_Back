using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4._0_C3_CrowdCtrl_Back.DAL;
using Project4._0_C3_CrowdCtrl_Back.Models;
using Project4._0_C3_CrowdCtrl_Back.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project4._0_C3_CrowdCtrl_Back.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecordingDeviceController : ControllerBase
    {
        private readonly DataContext _context;

        public RecordingDeviceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RecordingDevice>> GetRecordingDevices()
        {
            return await _context.RecordingDevices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordingDeviceById(int id)
        {
            var recordingDevice = await _context.RecordingDevices.FindAsync(id);
            return recordingDevice == null ? NotFound() : Ok(recordingDevice);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateRecordingDevice(RecordingDevice recordingDevice)
        {
            await _context.RecordingDevices.AddAsync(recordingDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateRecordingDevice), new { id = recordingDevice.RecordingDeviceId }, recordingDevice);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRecordingDevice(int id, RecordingDevice recordingDevice)
        {
            if (id != recordingDevice.RecordingDeviceId) return BadRequest();
            _context.Entry(recordingDevice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecordingDevice(int id)
        {
            var recordingDeviceToDelete = await _context.RecordingDevices.FindAsync(id);
            if (recordingDeviceToDelete == null) return NotFound();

            _context.RecordingDevices.Remove(recordingDeviceToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
