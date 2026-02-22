using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class HealthConsultantsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public HealthConsultantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListHealthConsultantsQuery query)
        {
            var healthConsultants = await _mediator.Send(query);

            return Result(healthConsultants);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetHealthConsultantQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SaveHealthConsultantCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteHealthConsultantCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
