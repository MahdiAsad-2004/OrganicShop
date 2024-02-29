using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.BLL.Extensions;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductDtos;

namespace OrganicShop.BLL.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductListDto>()
                .ForMember(m => m.UpdatedPrice, a => a.MapFrom(b => b.UpdatedPrice != null ? b.UpdatedPrice.ToToman() : b.Price.ToToman()))
                .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Category.Title))
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<CreateProductDto, Product>();


            CreateMap<UpdateProductDto, Product>();

        }

    }
}