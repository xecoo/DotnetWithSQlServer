using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Domain.Product;

namespace Project.Application.UseCases.RegisterProduct
{
    public class RegisterProductHandler : IRequestHandler<RegisterProductRequest, RegisterProductResponse>
    {
        private readonly IProductRepository repository;

        public RegisterProductHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<RegisterProductResponse> Handle(
            RegisterProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description);

            var products = await repository.CreateAsync(product);
        
            return new RegisterProductResponse();
        }
    }
}