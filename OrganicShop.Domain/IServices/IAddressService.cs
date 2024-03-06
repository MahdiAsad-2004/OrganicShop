using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;
using System.Xml.Schema;

namespace OrganicShop.Domain.IServices
{
    public interface IAddressService : IService<Address>
    {
        Task<PageDto<Address,AddressListDto,long>> GetAll(FilterAddressDto? filter = null , SortAddressDto? sort = null , PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateAddressDto create);

        Task<ServiceResponse> Update(UpdateAddressDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
