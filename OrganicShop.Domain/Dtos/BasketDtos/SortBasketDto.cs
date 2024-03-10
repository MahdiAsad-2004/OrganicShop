using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.BasketDtos
{
    // True for ascending ,,,, False for descending
    public class SortBasketDto : BaseSortDto<Entities.Basket, long>
    {
        public SortOrder? TotalPrice { get; set; } = null;
    }



}
