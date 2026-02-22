using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetHealthConsultantQueryHandler : IRequestHandler<GetHealthConsultantQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetHealthConsultantQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetHealthConsultantQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var healthConsultant = await _dbContext
            .HealthConsultants
            .Where(h => h.Id == request.Id)
            .FirstOrDefaultAsync();
        result.Value = healthConsultant;

        return result;
    }
}
