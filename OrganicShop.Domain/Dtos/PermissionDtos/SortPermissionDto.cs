using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class SortPermissionDto : BaseSortDto<Entities.Permission, byte>
    {
        public bool? Title { get; set; }
        public bool? EnTitle { get; set; }
    }


}
