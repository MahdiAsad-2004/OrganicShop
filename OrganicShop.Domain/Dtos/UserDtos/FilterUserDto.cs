using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class FilterUserDto : BaseFilterDto<Entities.User, long>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Role? Role { get; set; }
        public string? Email { get; set; }
    }





}
