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
    public class ListMedicalRecordsQueryHandler : IRequestHandler<ListMedicalRecordsQuery, OperationResult<PagedResult<MedicalRecord>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListMedicalRecordsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<MedicalRecord>>> Handle(ListMedicalRecordsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<MedicalRecord>>();
            result.Value = await _dbContext
                .MedicalRecords
                .OrderBy(x => x.Id)
                .GetPagedAsync<MedicalRecord>(request.Page, request.PageSize);

            return result;
        }
    }
}
