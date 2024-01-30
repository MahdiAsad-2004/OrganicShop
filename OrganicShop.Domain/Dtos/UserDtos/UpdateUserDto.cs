using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UpdateUserDto : BaseDto<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string? ProfileImage { get; set; }
    }





}
