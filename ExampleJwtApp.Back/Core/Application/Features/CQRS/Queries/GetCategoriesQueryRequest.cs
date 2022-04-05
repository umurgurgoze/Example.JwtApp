using ExampleJwtApp.Back.Core.Application.Dto;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
