using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class PatientsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListPatientsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetPatientQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SavePatientCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeletePatientCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
