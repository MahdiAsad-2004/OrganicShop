using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class CommentListDto : BaseListDto<long>
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
    }




}
