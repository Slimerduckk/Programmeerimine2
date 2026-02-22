using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class DeleteFoodRecordCommandHandler : IRequestHandler<DeleteFoodRecordCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteFoodRecordCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteFoodRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            await _dbContext
                .FoodRecords
                .Where(record => record.Id == request.Id)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
