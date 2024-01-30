using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.ContactUsDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class ContactUsMappers
    {
       
        public static ContactUs ToModel(this UpdateContactUsDto update, ContactUs ContactUs)
        {
            ContactUs.Address = update.Address.ToText();
            ContactUs.Description = update.Description.ToText();
            ContactUs.Email1 = update.Email1.ToText();
            ContactUs.Email2 = update.Email2 == null ? null : update.Email2.ToText();
            ContactUs.Phone1 = update.Phone1.ToText();
            ContactUs.Phone2 = update.Phone2 == null ? null : update.Phone2.ToText();
            ContactUs.Phone3 = update.Phone3 == null ? null : update.Phone3.ToText();
            ContactUs.PhoneNumber1 = update.PhoneNumber1.ToText();
            ContactUs.PhoneNumber2 = update.PhoneNumber2 == null ? null : update.PhoneNumber2.ToText();
            ContactUs.PhoneNumber3 = update.PhoneNumber3 == null ? null : update.PhoneNumber3.ToText();
            ContactUs.Office1 = update.Office1.ToText();
            ContactUs.Office2 = update.Office2 == null ? null : update.Office2.ToText();
            ContactUs.Office3 = update.Office3 == null ? null : update.Office3.ToText();

            return ContactUs;
        }


        public static UpdateContactUsDto ToUpdateDto(this ContactUs contactUs)
        {
            return new UpdateContactUsDto
            {
                Address = contactUs.Address,
                Description = contactUs.Description,
                Email1 = contactUs.Email1,
                Email2 = contactUs.Email2,
                Phone1 = contactUs.Phone1,
                Phone2 = contactUs.Phone2,
                Phone3 = contactUs.Phone3,
                PhoneNumber1 = contactUs.PhoneNumber1,
                PhoneNumber2 = contactUs.PhoneNumber2,
                PhoneNumber3 = contactUs.PhoneNumber3,
                Office1 = contactUs.Office1,
                Office2 = contactUs.Office2,
                Office3 = contactUs.Office3,
            };
        }







    }
}
