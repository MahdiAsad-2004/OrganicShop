using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BasketDtos
{
    // True for ascending ,,,, False for descending
    public class SortBasketDto : BaseSortDto<Entities.Basket, long>
    {
        public bool? TotalPrice { get; set; }
    }



}
