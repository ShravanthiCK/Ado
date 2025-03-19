using System;
using System.ComponentModel.DataAnnotations;

namespace HealthFitnessTrackerAPI.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string WorkoutType { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public int CaloriesBurned { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        
    }
}
