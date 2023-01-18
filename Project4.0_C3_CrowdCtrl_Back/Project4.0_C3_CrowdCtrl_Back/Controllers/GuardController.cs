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
    public class GuardController : ControllerBase
    {
        private readonly DataContext _context;

        public GuardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Guard>> GetGuards()
        {
            return await _context.Guards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuardById(int id)
        {
            var guard = await _context.Guards.FindAsync(id);
            return guard == null ? NotFound() : Ok(guard);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateGuard(Guard guard)
        {
            await _context.Guards.AddAsync(guard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateGuard), new { id = guard.UserId }, guard);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuard(int id, Guard guard)
        {
            if (id != guard.UserId) return BadRequest();
            _context.Entry(guard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuard(int id)
        {
            var guardToDelete = await _context.Guards.FindAsync(id);
            if (guardToDelete == null) return NotFound();

            _context.Guards.Remove(guardToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

