using ExampleJwtApp.Back.Core.Application.Dto;
using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductListDto> // Bu bir IRequesttir ve geriye ProductListDto türünden döner.
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
