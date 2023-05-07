using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation;
using MediatR;

namespace Project.Api.Helpers
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> validators;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestToValidate = new ValidationContext<TRequest>(request);

            var failures = validators
                .Select(v => v.Validate(requestToValidate))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
            
            return await next();
        }
    }
}
