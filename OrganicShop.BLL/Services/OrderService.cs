using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IOrderRepository _OrderRepository;
        private readonly IAddressRepository _AddressRepository;
        private readonly ICoProductRepository _CoProductRepository;
        private readonly IBasketRepository _BasketRepository;
        private readonly ITrackingStatusService _TrackingStatusesService;

        public OrderService(IApplicationUserProvider provider,IMapper mapper,IOrderRepository OrderRepository, IAddressRepository AddressRepository,
            ICoProductRepository coProductRepository, IBasketRepository basketRepository, ITrackingStatusService trackingStatusesService) : base(provider)
        {
            _Mapper = mapper;
            _OrderRepository = OrderRepository;
            _AddressRepository = AddressRepository;
            _CoProductRepository = coProductRepository;
            _BasketRepository = basketRepository;
            _TrackingStatusesService = trackingStatusesService;
        }

        #endregion


        public async Task<PageDto<Order, OrderListDto, long>> GetAll(FilterOrderDto? filter = null, SortOrderDto? sort = null, PagingDto? paging = null)
        {
            var query = _OrderRepository.GetQueryable()
                .Include(a => a.Receiver)
                .AsQueryable();

            if (filter == null) filter = new FilterOrderDto();
            if (sort == null) sort = new SortOrderDto();
            if (paging == null) paging = new PagingDto();

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
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<OrderListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateOrderDto create)
        {
            Order Order = _Mapper.Map<Order>(create);
            var Address = await _AddressRepository.GetAsNoTracking(create.AddressId);

            if (Address == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            Order.Address = Address;
            long orderId = await _OrderRepository.Add(Order, _AppUserProvider.User.Id);

            #region transfer coProdutcs from basket to order

            var coProducts = _CoProductRepository.GetQueryable()
                .Where(a => a.BasketId == create.BasketId)
                .AsTracking();
            foreach (var item in coProducts)
            {
                item.BasketId = null;
                item.OrderId = orderId;
                item.IsOrdered = true;
                await _CoProductRepository.Update(item, _AppUserProvider.User.Id);
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
                    await _CoProductRepository.Update(item, _AppUserProvider.User.Id);
                }
            }

            #endregion


            #region create tracking statuses

            var result1 = await _TrackingStatusesService.Create(new CreateTrackingStatusDto { OrderId = orderId });

            #endregion


            if (result1.Result != EntityResult.Success) 
                return new ServiceResponse(EntityResult.NotFound, _Message.SuccessUpdate());

            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateOrderDto update)
        {
            Order? Order = await _OrderRepository.GetAsTracking(update.Id);

            if (Order == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.SuccessUpdate());

            await _OrderRepository.Update(_Mapper.Map<Order>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Order? Order = await _OrderRepository.GetAsTracking(delete);

            if (Order == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.SuccessUpdate());

            await _OrderRepository.SoftDelete(Order, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
