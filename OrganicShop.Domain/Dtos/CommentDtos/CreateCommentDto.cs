using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public record CreateCommentDto
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; } = CommentStatus.Unread;
        public long? ParentId { get; set; }
        public long UserId { get; set; }
    }




}
