using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.BLL.Providers;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response;
using System.Reflection;
using System.Threading.Channels;

namespace OrganicShop.BLL.Services
{
    public class AddressService : Service<Address>, IAddressService
    {
        #region ctor
        
        //public CurrentUser _User {private get; init; }
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _Mapper;


        public AddressService(ApplicationUserProvider applicationUserProvider, IMapper mapper, IAddressRepository AddressRepository) : base(applicationUserProvider)
        {
            _AddressRepository = AddressRepository;
            _Mapper = mapper;
        }

        #endregion


        public async Task<PageDto<Address, AddressListDto, long>> GetAll(FilterAddressDto filter, SortAddressDto sort, PagingDto paging)
        {
            var query = _AddressRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(a => a.UserId == filter.UserId);

            #endregion

            #region sort

            query = sort.ApplyBaseSort(query);

            #endregion

            PageDto<Address, AddressListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<AddressListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }


     


        public async Task<ServiceResponse> Create(CreateAddressDto create)
        {
            if (await _AddressRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 4)
                return new ServiceResponse(EntityResult.MaxCreate, _Message.MaxCreate(4));

            Address Address = _Mapper.Map<Address>(create);
            await _AddressRepository.Add(Address, _AppUserProvider.User.Id);

            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateAddressDto update)
        {
            Address? Address = await _AddressRepository.GetAsTracking(update.Id);

            if (Address == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            if (Address.UserId != update.UserId)
                return new ServiceResponse(EntityResult.NotFound, _Message.NoAccess());

            await _AddressRepository.Update(_Mapper.Map<Address>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {

            Address? Address = await _AddressRepository.GetAsTracking(delete);

            if (Address == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _AddressRepository.SoftDelete(Address, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }


    }
}
