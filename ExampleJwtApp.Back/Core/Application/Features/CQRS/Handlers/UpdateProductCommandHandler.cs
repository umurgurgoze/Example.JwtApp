using ExampleJwtApp.Back.Core.Application.Features.CQRS.Commands;
using ExampleJwtApp.Back.Core.Application.Interfaces;
using ExampleJwtApp.Back.Core.Domain;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = request.Name;
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price = request.Price;
                await _repository.UpdateAsync(updatedProduct);
            }
            return Unit.Value;
        }
    }
}
