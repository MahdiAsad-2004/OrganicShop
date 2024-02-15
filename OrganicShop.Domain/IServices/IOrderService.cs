using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IOrderService : IService<Order>
    {
        Task<PageDto<Order,OrderListDto,long>> GetAll(FilterOrderDto filter,SortOrderDto sort,PagingDto paging);

        Task<ServiceResponse> Create(CreateOrderDto create);

        Task<ServiceResponse> Update(UpdateOrderDto update);
        
        Task<ServiceResponse> Delete(long id);
        
    }
}
