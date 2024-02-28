using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class ContactUsService : IContactUsService
    {
        #region ctor

        private readonly IContactUsRepository _ContactUsRepository;
        public Message<ContactUs> _Message { init; get; } = new Message<ContactUs>();

        public ContactUsService(IContactUsRepository ContactUsRepository)
        {
            this._ContactUsRepository = ContactUsRepository;
        }

        #endregion



        public async Task<UpdateContactUsDto> Get()
        {
            var contactUs = await _ContactUsRepository.GetQueryable().FirstAsync();
            return contactUs.ToUpdateDto();
        }



        public async Task<ServiceResponse> Update(UpdateContactUsDto update)
        {
            ContactUs? ContactUs = await _ContactUsRepository.GetQueryable().FirstAsync();

            if (ContactUs == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _ContactUsRepository.Update(update.ToModel(ContactUs), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }

    }
}
