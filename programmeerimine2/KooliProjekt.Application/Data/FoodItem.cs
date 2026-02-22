using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 1000)]
        public int? EnergyKcal { get; set; }
        [Range(0, 1000)]
        public decimal? FatGrams { get; set; }
        [Range(0, 1000)]
        public decimal? CarbohydrateGrams { get; set; }
        [Range(0, 1000)]
        public decimal? ProteinGrams { get; set; }
        [Range(0, 1000)]
        public decimal? SaltGrams { get; set; }

        public ICollection<FoodRecordItem> FoodRecordItems { get; set; } = new List<FoodRecordItem>();
    }
}
