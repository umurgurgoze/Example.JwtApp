using ExampleJwtApp.Back.Core.Application.Features.CQRS.Commands;
using ExampleJwtApp.Back.Core.Application.Interfaces;
using ExampleJwtApp.Back.Core.Domain;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Definition = request.Definition;
                await _repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
