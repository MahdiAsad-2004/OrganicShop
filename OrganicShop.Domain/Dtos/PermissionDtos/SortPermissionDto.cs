using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class SortPermissionDto : BaseSortDto<Entities.Permission, byte>
    {
        public SortOrder? Title { get; set; } = null;
        public SortOrder? EnTitle { get; set; } = null;
    }


}
