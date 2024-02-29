using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.TagDtos;
using AutoMapper;

namespace OrganicShop.BLL.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {

            CreateMap<Tag, TagListDto>();


            CreateMap<CreateTagDto, Tag>();


            CreateMap<UpdateTagDto, Tag>();

        }


    }
}
