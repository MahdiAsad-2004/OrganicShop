using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class FilterAddressDto : BaseFilterDto<Entities.Address, long>
    {
        public long? UserId { get; set; }
    }




}
