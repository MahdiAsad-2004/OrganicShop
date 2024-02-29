using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper.Execution;

namespace OrganicShop.BLL.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentListDto>()
                .ForMember(m => m.Date, a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.Status, a => a.MapFrom(b => b.Status.ToStringValue()));


            CreateMap<CreateCommentDto, Comment>();


            CreateMap<UpdateCommentDto, Comment>();

        }

    }
}
