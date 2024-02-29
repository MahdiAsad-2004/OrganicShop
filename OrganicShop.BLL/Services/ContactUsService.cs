using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;

namespace OrganicShop.BLL.Services
{
    public class ContactUsService : IContactUsService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IContactUsRepository _ContactUsRepository;
        public Message<ContactUs> _Message { init; get; } = new Message<ContactUs>();

        public ContactUsService(IMapper mapper,IContactUsRepository ContactUsRepository)
        {
            _Mapper = mapper;
            this._ContactUsRepository = ContactUsRepository;
        }

        #endregion



        public async Task<UpdateContactUsDto> Get()
        {
            var contactUs = await _ContactUsRepository.GetQueryable().FirstAsync();
            return _Mapper.Map<UpdateContactUsDto>(contactUs);
        }



        public async Task<ServiceResponse> Update(UpdateContactUsDto update)
        {
            ContactUs? ContactUs = await _ContactUsRepository.GetQueryable().FirstAsync();

            if (ContactUs == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _ContactUsRepository.Update(_Mapper.Map<ContactUs>(update), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }

    }
}
