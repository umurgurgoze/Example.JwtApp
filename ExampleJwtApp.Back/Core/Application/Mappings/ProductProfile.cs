using AutoMapper;
using ExampleJwtApp.Back.Core.Application.Dto;
using ExampleJwtApp.Back.Core.Domain;

namespace ExampleJwtApp.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
