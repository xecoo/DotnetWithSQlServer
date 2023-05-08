using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Controllers.Resources;
using Project.Application.UseCases.GetProducts;
using Project.Application.UseCases.RegisterProduct;

namespace Project.Api.Controllers
{
    [ApiController]
    [Route("api")]
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

        [HttpPost]
        [Route("Product")]
        public async Task<IActionResult> RegisterProduct(
            [FromBody] RegisterProductDto productDto,
            [FromServices] IMediator mediator)
        {
            var request = new RegisterProductRequest(productDto.Name, productDto.Description);
            
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}