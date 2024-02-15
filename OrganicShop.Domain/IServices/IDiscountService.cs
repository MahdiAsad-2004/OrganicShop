using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IDiscountService : IService<Discount>
    {
        Task<PageDto<Discount,DiscountListDto,int>> GetAll(FilterDiscountDto filter, SortDiscountDto sort,PagingDto paging);

        Task<ServiceResponse> Create(CreateDiscountDto create);

        Task<ServiceResponse> Update(UpdateDiscountDto update);
        
        Task<ServiceResponse> Delete(int id);
        
    }
}
