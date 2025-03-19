using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using HealthFitnessTrackerAPI.Data;
using HealthFitnessTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthAndFitnessTrackerAPI.Controllers
{

    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;

        }

        // ✅ Get all workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            // Make sure we're querying _context.Workouts, not _context.CalorieLogs
            var workouts = await _context.Workouts.ToListAsync();
            return Ok(workouts);
        }

        // ✅ Get a single workout by ID (returns only required fields)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout(int id)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
                return NotFound(new { message = "Workout not found." });

            return Ok(workout);
        }

        // ✅ Create a new workout
        [AllowAnonymous] // This allows access without authentication
        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] Workout workout)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Workout added successfully!" });
        }


        // ✅ Update an existing workout
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, [FromBody] Workout workout)
        {
            if (id != workout.Id)
                return BadRequest(new { message = "Workout ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingWorkout = await _context.Workouts.FindAsync(id);
            if (existingWorkout == null)
                return NotFound(new { message = "Workout not found." });

            // ✅ Update only modified fields
            existingWorkout.Date = workout.Date;
            existingWorkout.WorkoutType = workout.WorkoutType;

            existingWorkout.Duration = workout.Duration;
            existingWorkout.CaloriesBurned = workout.CaloriesBurned;
            existingWorkout.UserId = workout.UserId;

            await _context.SaveChangesAsync();
            return NoContent();


        }

        // ✅ Delete a workout
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
                return NotFound(new { message = "Workout not found." });

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
