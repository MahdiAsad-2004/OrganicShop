using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using System.Dynamic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrganicShop.BLL.Services
{
    public class AddressService : IAddressService
    {
        #region ctor

        private readonly IAddressRepository _AddressRepository;

        public AddressService(IAddressRepository AddressRepository)
        {
            this._AddressRepository = AddressRepository;
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

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateAddressDto create)
        {
            if (await _AddressRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 4)
                return EntityResultCreate.MaxCreate;

            Address Address = create.ToModel();
            await _AddressRepository.Add(Address,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateAddressDto update)
        {
            Address? Address = await _AddressRepository.GetAsTracking(update.Id);
            
            if (Address == null)
                return EntityResultUpdate.NotFound;

            if (Address.UserId != update.UserId)
                return EntityResultUpdate.NoAccess;

            await _AddressRepository.Update(update.ToModel(Address), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {

            Address? Address = await _AddressRepository.GetAsTracking(delete);

            if (Address == null)
                return EntityResultDelete.NotFound;

            await _AddressRepository.SoftDelete(Address, 1);
            return EntityResultDelete.success;
        }
    }
}
