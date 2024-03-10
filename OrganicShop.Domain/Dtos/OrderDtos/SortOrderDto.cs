using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class SortOrderDto : BaseSortDto<Entities.Order, long>
    {
        public SortOrder? TotalPrice { get; set; } = null;
    }




}
