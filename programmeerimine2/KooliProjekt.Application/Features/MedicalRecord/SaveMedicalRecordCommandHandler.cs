using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveMedicalRecordCommandHandler : IRequestHandler<SaveMedicalRecordCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveMedicalRecordCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var medicalRecord = new MedicalRecord();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(medicalRecord);
            }
            else {

                medicalRecord = await _dbContext.MedicalRecords.FindAsync(request.Id);
            }

            medicalRecord.PatientId = request.PatientId;
            medicalRecord.RecordDate = request.RecordDate;
            medicalRecord.Weight = request.Weight;
            medicalRecord.SugarLevel = request.SugarLevel;
            medicalRecord.BloodPressureDiastolic = request.BloodPressureDiastolic;
            medicalRecord.BloodPressureSystolic = request.BloodPressureSystolic;
            medicalRecord.BloodPressurePulse = request.BloodPressurePulse;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
