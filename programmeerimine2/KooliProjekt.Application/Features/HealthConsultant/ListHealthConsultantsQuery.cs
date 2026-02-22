using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features
{
    public class ListHealthConsultantsQuery : IRequest<OperationResult<PagedResult<HealthConsultant>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
