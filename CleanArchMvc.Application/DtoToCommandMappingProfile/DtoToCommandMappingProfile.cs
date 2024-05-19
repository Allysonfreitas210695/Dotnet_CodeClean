using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.DtoToCommandMappingProfile
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDto, ProductUpdateCommand>().ReverseMap();
        }
    }
}
