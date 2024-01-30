using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class FilterPermissionDto : BaseFilterDto<Entities.Permission, byte>
    {
        public byte? ParentId { get; set; }
        public long? UserId { get; set; }
    }


}
