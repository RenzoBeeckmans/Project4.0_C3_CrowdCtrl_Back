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
    public class EventTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public EventTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            return await _context.EventTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTypeById(int id)
        {
            var eventType = await _context.EventTypes.FindAsync(id);
            return eventType == null ? NotFound() : Ok(eventType);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateEventType(EventType eventType)
        {
            await _context.EventTypes.AddAsync(eventType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateEventType), new { id = eventType.EventTypeId }, eventType);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventType(int id, EventType eventType)
        {
            if (id != eventType.EventTypeId) return BadRequest();
            _context.Entry(eventType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventType(int id)
        {
            var eventTypeToDelete = await _context.EventTypes.FindAsync(id);
            if (eventTypeToDelete == null) return NotFound();

            _context.EventTypes.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
