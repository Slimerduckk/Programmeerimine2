using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class FoodRecord
    {
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        public MealType MealType { get; set; }
        public ICollection<FoodRecordItem> FoodRecordItems { get; set; } = new List<FoodRecordItem>();
    }

    public enum MealType { Breakfast, Lunch, Dinner, Snack }
}
