using MediatR;

namespace ExampleJwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest : IRequest // Bu bir IRequesttir.Delete işleminden sonra geriye bişey dönmez.
    {
        public int Id { get; set; }
        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
