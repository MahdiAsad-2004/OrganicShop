using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BasketDtos
{
    public class BasketListDto : BaseListDto<long>
    {
        public int TotalPrice { get; set; }
        public bool IsMain { get; set; }
        public int ProductsCount { get; set; }
    }



}
