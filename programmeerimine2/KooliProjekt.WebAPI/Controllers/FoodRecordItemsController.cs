using System;
using System.Linq;
using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using KooliProjekt.Application.Infrastructure.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class FoodRecordItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public FoodRecordItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListFoodRecordItemsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetFoodRecordItemQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SaveFoodRecordItemCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteFoodRecordItemCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
