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
    public class ListPatientsQueryHandler : IRequestHandler<ListPatientsQuery, OperationResult<PagedResult<Patient>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPatientsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<Patient>>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<Patient>>();
            result.Value = await _dbContext
                .Patients
                .OrderBy(x => x.Id)
                .GetPagedAsync<Patient>(request.Page, request.PageSize);

            return result;
        }
    }
}
