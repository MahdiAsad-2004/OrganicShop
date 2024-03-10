using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class SortCommentDto : BaseSortDto<Entities.Comment, long>
    {
        public SortOrder? Rate { get; set; } = null;
    }




}
