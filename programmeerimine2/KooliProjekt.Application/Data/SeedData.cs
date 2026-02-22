using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// 14.11.2025
    /// Testandmete generaator
    /// 
    /// Testandmed genereeritakse ainult siis kui mõni oluline 
    /// tabel on tühi.
    /// </summary>
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Genereerib andmed
        /// </summary>
        public void Generate()
        {
            if (_dbContext.Any())
            {
                return;
            }

            Random random = new Random();

            // Generate HealthConsultants
            List<HealthConsultant> healthConsultants = new List<HealthConsultant>();
            for (int i = 0; i < 5; i++)
            {
                healthConsultants.Add(new HealthConsultant());
            }
            _dbContext.HealthConsultants.AddRange(healthConsultants);
            _dbContext.SaveChanges();

            // Generate Patients
            List<Patient> patients = new List<Patient>();
            for (int i = 0; i < 15; i++)
            {
                patients.Add(new Patient
                {
                    HealthConsultantId = healthConsultants[random.Next(healthConsultants.Count)].Id
                });
            }
            _dbContext.Patients.AddRange(patients);
            _dbContext.SaveChanges();

            // Generate MedicalRecords
            for (int i = 0; i < 30; i++)
            {
                _dbContext.MedicalRecords.Add(new MedicalRecord
                {
                    PatientId = patients[random.Next(patients.Count)].Id,
                    RecordDate = DateTime.Now.AddDays(-random.Next(365)),
                    Weight = (decimal)(random.Next(50, 120) + random.NextDouble()),
                    SugarLevel = (decimal)(random.Next(70, 180) + random.NextDouble()),
                    BloodPressureSystolic = random.Next(100, 180),
                    BloodPressureDiastolic = random.Next(60, 120),
                    BloodPressurePulse = random.Next(60, 120)
                });
            }
            _dbContext.SaveChanges();

            // Generate FoodItems
            List<FoodItem> foodItems = new List<FoodItem>();
            string[] foodNames = { "Apple", "Banana", "Chicken", "Rice", "Bread", "Milk", "Egg", "Broccoli", "Salmon", "Olive Oil", "Yogurt", "Carrot" };
            for (int i = 0; i < foodNames.Length; i++)
            {
                foodItems.Add(new FoodItem
                {
                    Name = foodNames[i],
                    EnergyKcal = random.Next(50, 900),
                    FatGrams = (decimal)(random.Next(0, 50) + random.NextDouble()),
                    CarbohydrateGrams = (decimal)(random.Next(0, 80) + random.NextDouble()),
                    ProteinGrams = (decimal)(random.Next(0, 40) + random.NextDouble()),
                    SaltGrams = (decimal)(random.NextDouble() * 2)
                });
            }
            _dbContext.FoodItems.AddRange(foodItems);
            _dbContext.SaveChanges();

            // Generate FoodRecords
            List<FoodRecord> foodRecords = new List<FoodRecord>();
            MealType[] mealTypes = { MealType.Breakfast, MealType.Lunch, MealType.Dinner, MealType.Snack };
            for (int i = 0; i < 40; i++)
            {
                foodRecords.Add(new FoodRecord
                {
                    PatientId = patients[random.Next(patients.Count)].Id,
                    RecordDate = DateTime.Now.AddDays(-random.Next(30)),
                    MealType = mealTypes[random.Next(mealTypes.Length)]
                });
            }
            _dbContext.FoodRecords.AddRange(foodRecords);
            _dbContext.SaveChanges();

            // Generate FoodRecordItems
            for (int i = 0; i < 60; i++)
            {
                _dbContext.FoodRecordItems.Add(new FoodRecordItem
                {
                    FoodRecordId = foodRecords[random.Next(foodRecords.Count)].Id,
                    FoodItemId = foodItems[random.Next(foodItems.Count)].Id,
                    Quantity = random.Next(1, 10) + random.NextDouble()
                });
            }
            _dbContext.SaveChanges();
        }
    }
}
