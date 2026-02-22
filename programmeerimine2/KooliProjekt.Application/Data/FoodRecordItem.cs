using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class FoodRecordItem
    {
        public int Id { get; set; }
        public int FoodRecordId { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        [Range(1, 10)]
        public double Quantity { get; set; }
    }
}
