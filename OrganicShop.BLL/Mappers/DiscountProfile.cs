using AutoMapper;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {

            CreateMap<Discount, DiscountListDto>()
                .ForMember(m => m.CreateDate , a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.IsActive , a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<CreateDiscountDto, Discount>();


            CreateMap<UpdateDiscountDto, Discount>();

        }


    }
}
