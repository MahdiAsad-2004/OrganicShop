using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CategoryDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CategoryDtos;

namespace OrganicShop.BLL.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {

            CreateMap<Category, CategoryListDto>()
                .ForMember(m => m.ParentTitle , a => a.MapFrom(b => b.Parent != null ? b.Parent.Title : null))
                .ForMember(m => m.ParentEnTitle , a => a.MapFrom(b => b.Parent != null ? b.Parent.EnTitle : null));


            CreateMap<CreateCategoryDto, Category>();


            CreateMap<UpdateCategoryDto, Category>();

        }


    }
}
