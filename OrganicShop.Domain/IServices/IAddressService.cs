using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IAddressService
    {
        Task<PageDto<Address,AddressListDto,long>> GetAll(FilterAddressDto filter , SortAddressDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreateAddressDto create);

        Task<EntityResultUpdate> Update(UpdateAddressDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
