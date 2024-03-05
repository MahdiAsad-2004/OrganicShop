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
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class ContactUsService : Service<ContactUs>, IContactUsService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IContactUsRepository _ContactUsRepository;

        public ContactUsService(IApplicationUserProvider provider,IMapper mapper,IContactUsRepository ContactUsRepository) : base(provider)
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

            await _ContactUsRepository.Update(_Mapper.Map<ContactUs>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }

    }
}
