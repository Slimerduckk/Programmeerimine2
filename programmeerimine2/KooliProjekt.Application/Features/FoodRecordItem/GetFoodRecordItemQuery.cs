using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;

public class GetFoodRecordItemQuery : IRequest<OperationResult<object>>
{
    public int Id { get; set; }
}
