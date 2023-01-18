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
    public class IncidentController : ControllerBase
    {
        private readonly DataContext _context;

        public IncidentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Incident>> GetIncidents()
        {
            return await _context.Incidents.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidentById(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            return incident == null ? NotFound() : Ok(incident);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateIncident(Incident incident)
        {
            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateIncident), new { id = incident.IncidentId }, incident);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncident(int id, Incident incident)
        {
            if (id != incident.IncidentId) return BadRequest();
            _context.Entry(incident).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncident(int id)
        {
            var incidentToDelete = await _context.Incidents.FindAsync(id);
            if (incidentToDelete == null) return NotFound();

            _context.Incidents.Remove(incidentToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

