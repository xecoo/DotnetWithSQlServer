using MediatR;

namespace Project.Application.UseCases.RegisterProduct
{
    public class RegisterProductRequest : IRequest<RegisterProductResponse>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public RegisterProductRequest(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}