using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.UserDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class UserMappers
    {
        public static UserListDto ToListDto(this User user)
        {
            return new UserListDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                ProfileImage = user.ProfileImage,
                Addresses = user.Addresses != null ? user.Addresses.ToList() : new List<Address>()
            };
        }

        public static User ToModel(this CreateUserDto create)
        {
            return new User()
            {
                Name = create.Name.Trim(),
                Password = create.Password.Trim(),
                PhoneNumber = create.PhoneNumber.Trim().ToLower(),
                Email = create.Email.Trim().ToLower(),   
                Role = create.Role,
            };
        }

        public static User ToModel(this UpdateUserDto update, User user)
        {
            user.Name = update.Name.Trim();
            user.ProfileImage = update.ProfileImage;
            return user;
        }









    }
}
