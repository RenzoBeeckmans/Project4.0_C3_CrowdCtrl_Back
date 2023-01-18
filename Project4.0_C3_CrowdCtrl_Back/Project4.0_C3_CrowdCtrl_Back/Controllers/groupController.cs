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
    public class GroupController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            return group == null ? NotFound() : Ok(group);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateGroup(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateGroup), new { id = group.GroupId }, group);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGroup(int id, Group group)
        {
            if (id != group.GroupId) return BadRequest();
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            var groupToDelete = await _context.Groups.FindAsync(id);
            if (groupToDelete == null) return NotFound();

            _context.Groups.Remove(groupToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

