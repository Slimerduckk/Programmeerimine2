using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodRecordItemCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public int FoodRecordId { get; set; }
        public int FoodItemId { get; set; }
        [Range(1, 10)]
        public double Quantity { get; set; }
    }
}
