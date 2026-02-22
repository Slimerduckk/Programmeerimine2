using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetFoodRecordItemQueryHandler : IRequestHandler<GetFoodRecordItemQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetFoodRecordItemQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetFoodRecordItemQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodRecordItem = await _dbContext
            .FoodRecordItems
            .Where(f => f.Id == request.Id)
            .FirstOrDefaultAsync();
        result.Value = foodRecordItem;

        return result;
    }
}
