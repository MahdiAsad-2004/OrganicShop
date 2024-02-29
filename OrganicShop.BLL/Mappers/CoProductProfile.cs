using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.CoProductDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CoProductDtos;

namespace OrganicShop.BLL.Mappers
{
    public class CoProductProfile : Profile
    {
        public CoProductProfile()
        {

            CreateMap<CoProduct, CoProductListDto>()
                .ForMember(m => m.Price , a => a.MapFrom(b => b.Product.Price))
                .ForMember(m => m.UpdatedPrice , a => a.MapFrom(b => b.Product.UpdatedPrice));


            CreateMap<CreateCoProductDto, CoProduct>();


            CreateMap<UpdateCoProductDto, CoProduct>();

        }


    }
}
