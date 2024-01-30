using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public record CreateUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string? ProfileImage { get; set; }
    }





}
