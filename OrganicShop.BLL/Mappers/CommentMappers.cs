using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CommentDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class CommentMappers
    {
        public static CommentListDto ToListDto(this Comment Comment)
        {
            return new CommentListDto
            {
                Id = Comment.Id,
                Rate = Comment.Rate,
                Text = Comment.Text,
                Status = Comment.Status.ToStringValue(),
                UserId = Comment.UserId,
                Date = Comment.BaseEntity.CreateDate,
                UserName = Comment.User.Name,
            };
        }

        public static Comment ToModel(this CreateCommentDto create)
        {
            return new Comment()
            {
                Rate = create.Rate,
                Text = create.Text.ToText(),
                Status = create.Status,
                UserId = create.UserId,
            };
        }

        public static Comment ToModel(this UpdateCommentDto update, Comment Comment)
        {
            Comment.Status = update.Status;
            return Comment;
        }









    }
}
