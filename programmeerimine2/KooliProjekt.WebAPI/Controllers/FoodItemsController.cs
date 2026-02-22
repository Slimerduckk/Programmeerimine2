using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class FoodItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public FoodItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListFoodItemsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetFoodItemQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SaveFoodItemCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteFoodItemCommand query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
