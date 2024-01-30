using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IOrderService
    {
        Task<PageDto<Order,OrderListDto,long>> GetAll(FilterOrderDto filter,SortOrderDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateOrderDto create);

        Task<EntityResultUpdate> Update(UpdateOrderDto update);
        
        Task<EntityResultDelete> Delete(long id);
        
    }
}
