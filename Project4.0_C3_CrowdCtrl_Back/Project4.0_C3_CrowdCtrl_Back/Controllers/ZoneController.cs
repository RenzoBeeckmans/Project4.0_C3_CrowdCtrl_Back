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
    public class ZoneController : ControllerBase
    {
        private readonly DataContext _context;

        public ZoneController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Zone>> GetZones()
        {
            return await _context.Zones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZoneById(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            return zone == null ? NotFound() : Ok(zone);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateZone(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateZone), new { id = zone.ZoneId }, zone);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateZone(int id, Zone zone)
        {
            if (id != zone.ZoneId) return BadRequest();
            _context.Entry(zone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteZone(int id)
        {
            var zoneToDelete = await _context.Zones.FindAsync(id);
            if (zoneToDelete == null) return NotFound();

            _context.Zones.Remove(zoneToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
