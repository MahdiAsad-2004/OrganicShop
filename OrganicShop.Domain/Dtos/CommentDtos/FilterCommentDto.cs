using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class FilterCommentDto : BaseFilterDto<Entities.Comment, long>
    {
        public CommentStatus? Status { get; set; }
        public long? UserId { get; set; }
    }




}
