using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetPatientQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var patient = await _dbContext
            .Patients
            .Where(p => p.Id == request.Id)
            .FirstOrDefaultAsync();
        result.Value = patient;

        return result;
    }
}
