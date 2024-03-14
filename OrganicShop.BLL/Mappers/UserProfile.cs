using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.UserDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.UserDtos;

namespace OrganicShop.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserListDto>()
                //.ForMember(m => m.Addresses, a => a.MapFrom(b => b.Addresses != null ? b.Addresses : new List<Address>()))
                .ForMember(m => m.Email, a => a.AddTransform(b => b.ToLower()));


            CreateMap<CreateUserDto, User>();


            CreateMap<UpdateUserDto, User>();

        }


    }
}
