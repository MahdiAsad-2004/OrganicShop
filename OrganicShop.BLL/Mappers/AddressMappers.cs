using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public static class AddressMappers
    {
        public static AddressListDto ToListDto(this Address Address)
        {
            return new AddressListDto
            {
                Id = Address.Id,
                Title = Address.Title,
                Text = Address.Text,
                PostCode = Address.PostCode,
                Phone = Address.Phone,
            };
        }

        public static Address ToModel(this CreateAddressDto create)
        {
            return new Address()
            {
                UserId = create.UserId,
                Title = create.Title.ToText(),
                Text = create.Text.ToText(),
                PostCode = create.PostCode.ToText(),
                Phone = create.Phone.ToText(),
            };
        }

        public static Address ToModel(this UpdateAddressDto update, Address Address)
        {
            Address.Title = update.Title.ToText();
            Address.Text = update.Text.ToText();
            Address.PostCode = update.PostCode.ToText();
            Address.Phone = update.Phone.ToText();
            return Address;
        }









    }
}
