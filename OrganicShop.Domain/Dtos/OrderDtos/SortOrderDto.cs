using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class SortOrderDto : BaseSortDto<Entities.Order, long>
    {
        public bool? TotalPrice { get; set; }
    }




}
