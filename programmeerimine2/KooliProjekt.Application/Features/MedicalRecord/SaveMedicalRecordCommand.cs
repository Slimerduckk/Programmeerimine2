using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features
{
    public class SaveMedicalRecordCommand : IRequest<OperationResult>, ITransactional
    {

        //This will be considered as primary key to find and existing record. In case of creating a new record it will be auto set by the db
        public int Id { get; set; } 
        public int PatientId { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? SugarLevel { get; set; }
        public int? BloodPressureSystolic { get; set; }
        public int? BloodPressureDiastolic { get; set; }
        public int? BloodPressurePulse { get; set; }
    }
}
