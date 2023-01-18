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
    public class FeedbackController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedbackController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> GetFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            return feedback == null ? NotFound() : Ok(feedback);
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<ActionResult> CreateFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateFeedback), new { id = feedback.FeedbackId }, feedback);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedback(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackId) return BadRequest();
            _context.Entry(feedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var feedbackToDelete = await _context.Feedbacks.FindAsync(id);
            if (feedbackToDelete == null) return NotFound();

            _context.Feedbacks.Remove(feedbackToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
