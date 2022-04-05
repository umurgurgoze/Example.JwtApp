using AutoMapper;
using ExampleJwtApp.Back.Core.Application.Dto;
using ExampleJwtApp.Back.Core.Domain;

namespace ExampleJwtApp.Back.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
