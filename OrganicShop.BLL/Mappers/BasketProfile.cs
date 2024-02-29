using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.BasketDtos;
using OrganicShop.Domain.Dtos.BasketDtos;
using AutoMapper;

namespace OrganicShop.BLL.Mappers
{
    public class BasketProfile : Profile
    {

        public BasketProfile()
        {

            CreateMap<Basket, BasketListDto>()
                .ForMember(m => m.ProductsCount , a => a.MapFrom(b => b.CoProducts.Count));


            CreateMap<CreateBasketDto, Basket>();


            CreateMap<UpdateBasketDto, Basket>();

        }




    }
}
