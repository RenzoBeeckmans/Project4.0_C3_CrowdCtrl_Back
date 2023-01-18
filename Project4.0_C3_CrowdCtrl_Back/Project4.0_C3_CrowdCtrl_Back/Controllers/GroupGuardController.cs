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
    public class GroupGuardController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupGuardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<GroupGuard>> GetGroupGuards()
        {
            return await _context.GroupGuards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupGuardById(int id)
        {
            var groupGuard = await _context.GroupGuards.FindAsync(id);
            return groupGuard == null ? NotFound() : Ok(groupGuard);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateGroupGuard(GroupGuard groupGuard)
        {
            await _context.GroupGuards.AddAsync(groupGuard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateGroupGuard), new { id = groupGuard.GroupGuardId }, groupGuard);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGroupGuard(int id, GroupGuard groupGuard)
        {
            if (id != groupGuard.GroupGuardId) return BadRequest();
            _context.Entry(groupGuard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroupGuard(int id)
        {
            var groupGuardToDelete = await _context.GroupGuards.FindAsync(id);
            if (groupGuardToDelete == null) return NotFound();

            _context.GroupGuards.Remove(groupGuardToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

