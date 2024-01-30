using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class SortCommentDto : BaseSortDto<Entities.Comment, long>
    {
        public bool? Rate { get; set; }
    }




}
