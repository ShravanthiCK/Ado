using System;
using System.ComponentModel.DataAnnotations;

namespace HealthFitnessTrackerAPI.Models
{
    public class CalorieLog
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FoodItem { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        
    }
}
