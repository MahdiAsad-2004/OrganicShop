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
                Name = create.Name,
                Password = create.Password,
                PhoneNumber = create.PhoneNumber.ToLower(),
                Email = create.Email.ToLower(),   
                Role = create.Role,
                ProfileImage = create.ProfileImage,
            };
        }

        public static User ToModel(this UpdateUserDto update, User user)
        {
            user.Name = update.Name;
            user.Email = update.Email.ToLower();
            user.Role = update.Role;    
            user.ProfileImage = update.ProfileImage;
            return user;
        }









    }
}
