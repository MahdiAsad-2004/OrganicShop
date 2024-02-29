using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.PropertyDtos;
using AutoMapper;

namespace OrganicShop.BLL.Mappers
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {

            CreateMap<Property, PropertyListDto>();


            CreateMap<CreatePropertyDto, Property>();


            CreateMap<UpdatePropertyDto, Property>();

        }


    }
}
