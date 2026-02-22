using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetMedicalRecordQueryHandler : IRequestHandler<GetMedicalRecordQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetMedicalRecordQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetMedicalRecordQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var medicalRecord = await _dbContext
            .MedicalRecords
            .Where(record => record.Id == request.Id)
            .FirstOrDefaultAsync();
        result.Value = medicalRecord;

        return result;
    }
}