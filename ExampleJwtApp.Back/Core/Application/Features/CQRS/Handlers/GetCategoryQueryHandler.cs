using AutoMapper;
using ExampleJwtApp.Back.Core.Application.Dto;
using ExampleJwtApp.Back.Core.Application.Features.CQRS.Queries;
using ExampleJwtApp.Back.Core.Application.Interfaces;
using ExampleJwtApp.Back.Core.Domain;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}
