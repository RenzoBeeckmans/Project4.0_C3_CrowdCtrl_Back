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
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            return @event == null ? NotFound(): Ok(@event);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateEvent(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateEvent),new {id = @event.EventId}, @event);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, Event @event)
        {
            if (id != @event.EventId) return BadRequest();
            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null) return NotFound();

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
