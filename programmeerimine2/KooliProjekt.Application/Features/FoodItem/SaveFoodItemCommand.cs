using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodItemCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 1000)]
        public int? EnergyKcal { get; set; }
        [Range(0, 1000)]
        public decimal? FatGrams { get; set; }
        [Range(0, 1000)]
        public decimal? CarbohydrateGrams { get; set; }
        [Range(0, 1000)]
        public decimal? ProteinGrams { get; set; }
        [Range(0, 1000)]
        public decimal? SaltGrams { get; set; }
    }
}
