using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features
{
    public class SaveHealthConsultantCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
