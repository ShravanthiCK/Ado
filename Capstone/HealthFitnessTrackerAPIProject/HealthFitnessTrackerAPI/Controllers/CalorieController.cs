using Microsoft.AspNetCore.Mvc;
using HealthFitnessTrackerAPI.Data; // Adjust namespace if needed
using HealthFitnessTrackerAPI.Models; // Adjust namespace if needed
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace HealthAndFitnessTracker.Controllers
{

    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class CalorieLogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalorieLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CalorieLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalorieLog>>> GetCalorieLogs()
        {
            return await _context.CalorieLogs.ToListAsync();
        }

        // GET: api/CalorieLog/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CalorieLog>> GetCalorieLog(int id)
        {
            var calorieLog = await _context.CalorieLogs.FindAsync(id);
            if (calorieLog == null) return NotFound(new { message = "Calorie log not found" });

            return Ok(calorieLog);
        }

        // ✅ FIXED: Removed duplicate [HttpPost] and ensured only one POST method
        // POST: api/CalorieLog
        [HttpPost]
        public async Task<IActionResult> CreateCalorieLog([FromBody] CalorieLog calorieLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input data", errors = ModelState });
            }

            try
            {
                _context.CalorieLogs.Add(calorieLog);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Calorie log added successfully!" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Database error", error = ex.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }


        // PUT: api/CalorieLog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalorieLog(int id, [FromBody] CalorieLog calorieLog)
        {
            if (id != calorieLog.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            _context.Entry(calorieLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CalorieLogs.Any(e => e.Id == id))
                    return NotFound(new { message = "Calorie log not found" });

                throw;
            }
        }

        // DELETE: api/CalorieLog/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalorieLog(int id)
        {
            var calorieLog = await _context.CalorieLogs.FindAsync(id);
            if (calorieLog == null)
            {
                return NotFound(new { message = "Calorie log not found" });
            }

            _context.CalorieLogs.Remove(calorieLog);
            await _context.SaveChangesAsync();
            return NoContent();
        }
       

    }
}