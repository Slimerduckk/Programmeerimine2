using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodItemCommandHandler : IRequestHandler<SaveFoodItemCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveFoodItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveFoodItemCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodItem = new FoodItem();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(foodItem);
            }
            else
            {
                foodItem = await _dbContext.FoodItems.FindAsync(request.Id);
            }

            foodItem.Name = request.Name;
            foodItem.EnergyKcal = request.EnergyKcal;
            foodItem.FatGrams = request.FatGrams;
            foodItem.CarbohydrateGrams = request.CarbohydrateGrams;
            foodItem.ProteinGrams = request.ProteinGrams;
            foodItem.SaltGrams = request.SaltGrams;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
