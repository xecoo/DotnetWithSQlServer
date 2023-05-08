using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Domain.Product;

namespace Project.Application.UseCases.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductRepository repository;

        public GetProductsHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetProductsResponse> Handle(
            GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();
        
            return MapProductsResponse(products);
        }

        private GetProductsResponse MapProductsResponse(List<Product> products)
        {
            var getProductsResponse = new GetProductsResponse();

            getProductsResponse.Products = new List<ProductDto>();

            foreach(var product in products)
            {
                getProductsResponse.Products.Add(
                    new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description
                    }
                );
            }

            return getProductsResponse;
        }
    }
}