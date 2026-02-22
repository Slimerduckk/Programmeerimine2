using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features
{
    public class ListFoodItemsQueryHandler : IRequestHandler<ListFoodItemsQuery, OperationResult<PagedResult<FoodItem>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListFoodItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<FoodItem>>> Handle(ListFoodItemsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<FoodItem>>();
            result.Value = await _dbContext
                .FoodItems
                .OrderBy(x => x.Id)
                .GetPagedAsync<FoodItem>(request.Page, request.PageSize);

            return result;
        }
    }
}
