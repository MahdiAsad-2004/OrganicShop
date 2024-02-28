using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UpdateUserDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public string? ProfileImage { get; set; }
        public string Password { get; set; }
    }





}
