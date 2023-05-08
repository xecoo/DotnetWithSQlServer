using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.GetProducts;
using Project.Infra.Data;

namespace Project.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProducts(
            [FromServices] IMediator mediator)
        {
            var request = new GetProductsRequest();
            
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}