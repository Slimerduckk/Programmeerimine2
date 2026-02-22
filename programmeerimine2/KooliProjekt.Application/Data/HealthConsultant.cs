using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    public class HealthConsultant
    {
        public int Id { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
