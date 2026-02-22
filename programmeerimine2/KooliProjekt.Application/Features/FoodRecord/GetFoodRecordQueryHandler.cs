using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetFoodRecordQueryHandler : IRequestHandler<GetFoodRecordQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetFoodRecordQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetFoodRecordQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodRecord = await _dbContext
            .FoodRecords
            .Where(f => f.Id == request.Id)
            .Include(f => f.FoodRecordItems)
            .FirstOrDefaultAsync();
        result.Value = foodRecord;

        return result;
    }
}
