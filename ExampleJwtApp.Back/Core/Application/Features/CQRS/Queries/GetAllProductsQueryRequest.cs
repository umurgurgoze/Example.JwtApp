using ExampleJwtApp.Back.Core.Application.Dto;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>> //Bu query List<ProductListDto> dönecek ve buradaki propları kullanacak.
    {
    }
}
