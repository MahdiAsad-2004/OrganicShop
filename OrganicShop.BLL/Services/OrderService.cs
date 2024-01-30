using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        #region ctor

        private readonly IOrderRepository _OrderRepository;
        private readonly IAddressRepository _AddressRepository;
        private readonly ICoProductRepository _CoProductRepository;
        private readonly IBasketRepository _BasketRepository;
        private readonly ITrackingStatusService _TrackingStatusesService;

        public OrderService(IOrderRepository OrderRepository, IAddressRepository addressRepository, ICoProductRepository coProductRepository, 
            IBasketRepository basketRepository, ITrackingStatusService trackingStatusesService)
        {
            _OrderRepository = OrderRepository;
            _AddressRepository = addressRepository;
            _CoProductRepository = coProductRepository;
            _BasketRepository = basketRepository;
            _TrackingStatusesService = trackingStatusesService;
        }

        #endregion


        public async Task<PageDto<Order, OrderListDto, long>> GetAll(FilterOrderDto filter, SortOrderDto sort, PagingDto paging)
        {
            var query = _OrderRepository.GetQueryable()
                .Include(a => a.Receiver)
                .AsQueryable();

            #region flters

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(a => a.ReceiverId == filter.UserId);

            if (filter.UserPhoneNumber != null)
                query = query.Where(a => EF.Functions.Like(a.Receiver.PhoneNumber, $"%{filter.UserPhoneNumber}%"));

            if (filter.TrackingCode != null)
                query = query.Where(a => EF.Functions.Like(a.TrackingCode, $"%{filter.TrackingCode}%"));

            if (filter.OrderStatus != null)
                query = query.Where(a => a.OrderStatus == filter.OrderStatus);

            if (filter.DeliveryType != null)
                query = query.Where(a => a.DeliveryType == filter.DeliveryType);

            #endregion

            #region sort

            if (sort.TotalPrice == true) query = query.OrderBy(a => a.TotalPrice);
            if (sort.TotalPrice == false) query = query.OrderByDescending(a => a.TotalPrice);

            #endregion


            PageDto<Order, OrderListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateOrderDto create)
        {
            Order Order = create.ToModel();
            var address = await _AddressRepository.GetAsNoTracking(create.AddressId);
            if (address == null)
                return EntityResultCreate.NotFound;

            Order.Address = address;
            long orderId = await _OrderRepository.Add(Order, 1);

            #region transfer coProdutcs from basket to order

            var coProducts = _CoProductRepository.GetQueryable()
                .Where(a => a.BasketId == create.BasketId)
                .AsTracking();
            foreach (var item in coProducts)
            {
                item.BasketId = null;
                item.OrderId = orderId;
                item.IsOrdered = true;
                await _CoProductRepository.Update(item, 1);
            }

            #endregion


            #region transfer nextBasket coProducts to mainBasket

            var nextBasket = await _BasketRepository.GetQueryable()
                .Include(a => a.CoProducts)
                .FirstOrDefaultAsync(a => a.IsMain == false && a.UserId == create.UserId);
            if (nextBasket != null)
            {
                foreach (var item in nextBasket.CoProducts)
                {
                    item.BasketId = create.BasketId;
                    await _CoProductRepository.Update(item, 1);
                }
            }

            #endregion


            #region create tracking statuses

            var result1 = await _TrackingStatusesService.Create(new CreateTrackingStatusDto { OrderId = orderId });

            #endregion


            if (result1 != EntityResultCreate.success) return EntityResultCreate.Failed;
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateOrderDto update)
        {
            Order? Order = await _OrderRepository.GetAsTracking(update.Id);

            if (Order == null)
                return EntityResultUpdate.NotFound;

            await _OrderRepository.Update(update.ToModel(Order), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {
            Order? Order = await _OrderRepository.GetAsTracking(delete);

            if (Order == null)
                return EntityResultDelete.NotFound;

            await _OrderRepository.SoftDelete(Order, 1);
            return EntityResultDelete.success;
        }
    }
}
