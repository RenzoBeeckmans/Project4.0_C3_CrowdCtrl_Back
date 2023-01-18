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
    public class EventUserController : ControllerBase
    {
        private readonly DataContext _context;

        public EventUserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<EventUser>> GetEventUsers()
        {
            return await _context.EventUsers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventUserById(int id)
        {
            var eventUser = await _context.EventUsers.FindAsync(id);
            return eventUser == null ? NotFound() : Ok(eventUser);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateEventUser(EventUser eventUser)
        {
            await _context.EventUsers.AddAsync(eventUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateEventUser), new { id = eventUser.EventUserId }, eventUser);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventUser(int id, EventUser eventUser)
        {
            if (id != eventUser.EventUserId) return BadRequest();
            _context.Entry(eventUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventUser(int id)
        {
            var eventUserToDelete = await _context.EventUsers.FindAsync(id);
            if (eventUserToDelete == null) return NotFound();

            _context.EventUsers.Remove(eventUserToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
