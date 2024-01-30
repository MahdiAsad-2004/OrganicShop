using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BaketDtos
{
    public class BasketListDto : BaseDto<long>
    {
        public int TotalPrice { get; set; }
        public bool IsMain { get; set; }
        public int ProductsCount { get; set; }
    }



}
