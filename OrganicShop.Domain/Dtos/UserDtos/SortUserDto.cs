using OrganicShop.Domain.Dtos.Base;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class SortUserDto : BaseSortDto<Entities.User, long>
    {
        public bool? Name { get; set; }
    }





}
