using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.BLL.Providers;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{


    public class AddressService : IAddressService
    {
        #region ctor

        //public CurrentUser _User {private get; init; }
        private readonly IAddressRepository _AddressRepository;
        public Message<Address> _Message { get; init; } = new Message<Address>();

        public AddressService(/*CurrentUserProvider currentUserProvider,*/ IAddressRepository AddressRepository)
        {
            this._AddressRepository = AddressRepository;
            //this._User = currentUserProvider._User;
        }

        #endregion



        public async Task<PageDto<Address,AddressListDto,long>> GetAll(FilterAddressDto filter , SortAddressDto sort , PagingDto paging)
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
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);


            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateAddressDto create)
        {
            if (await _AddressRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 4)
                return new ServiceResponse(EntityResult.MaxCreate , _Message.MaxCreate(4));

            Address Address = create.ToModel();
            await _AddressRepository.Add(Address,1);
            
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateAddressDto update)
        {
            Address? Address = await _AddressRepository.GetAsTracking(update.Id);

            if (Address == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            if (Address.UserId != update.UserId)
                return new ServiceResponse(EntityResult.NotFound, _Message.NoAccess());

            await _AddressRepository.Update(update.ToModel(Address), 1);
            return new ServiceResponse(EntityResult.Success , _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {

            Address? Address = await _AddressRepository.GetAsTracking(delete);

            if (Address == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _AddressRepository.SoftDelete(Address, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }


    }
}
