using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetFoodItemQueryHandler : IRequestHandler<GetFoodItemQuery, OperationResult<object>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetFoodItemQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<object>> Handle(GetFoodItemQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodItem = await _dbContext
            .FoodItems
            .Where(f => f.Id == request.Id)
            .FirstOrDefaultAsync();
        result.Value = foodItem;

        return result;
    }
}
