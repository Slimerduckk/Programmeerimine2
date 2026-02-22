using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Range(0, 1000)]
        public decimal? Weight { get; set; }
        [Range(0, 1000)]
        public decimal? SugarLevel { get; set; }
        [Range(0, 1000)]
        public int? BloodPressureSystolic { get; set; }
        [Range(0, 1000)]
        public int? BloodPressureDiastolic { get; set; }
        [Range(0, 1000)]
        public int? BloodPressurePulse { get; set; }
    }
}
