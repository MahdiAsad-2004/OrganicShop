using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IDiscountService
    {
        Task<PageDto<Discount,DiscountListDto,int>> GetAll(FilterDiscountDto filter, SortDiscountDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateDiscountDto create);

        Task<EntityResultUpdate> Update(UpdateDiscountDto update);
        
        Task<EntityResultDelete> Delete(int id);
        
    }
}
