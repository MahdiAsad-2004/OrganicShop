using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class TrackingStatusService : ITrackingStatusService
    {

        #region ctor

        private readonly ITrackingStatusRepository _TrackingStatusRepository;
        private readonly IOrderRepository _OrderRepository;
        public Message<TrackingStatus> _Message { get; }

        public TrackingStatusService(ITrackingStatusRepository TrackingStatusRepository,IOrderRepository orderRepository)
        {
            _TrackingStatusRepository = TrackingStatusRepository;
            _OrderRepository = orderRepository;
        }

        #endregion



        public async Task<PageDto<TrackingStatus,TrackingStatusListDto,long>> GetAll(FilterTrackingStatusDto filter , SortTrackingStatusDto sort , PagingDto paging)
        {
            var query = _TrackingStatusRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.DoneStatus != null)
                query = query.Where(q => q.DoneStatus >= filter.DoneStatus);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Step == true) query = query.OrderBy(o => o.Step);
            if (sort.Step == false) query = query.OrderByDescending(o => o.Step);

            #endregion

            PageDto<TrackingStatus, TrackingStatusListDto,long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateTrackingStatusDto create)
        {
            //TrackingStatus TrackingStatus = create.ToModel();

            if (_OrderRepository.GetQueryable().Any(a => a.Id == create.OrderId) == false)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound(typeof(Order)));

            if(_TrackingStatusRepository.GetQueryable().Any(a => a.OrderId == create.OrderId) == true)
                return new ServiceResponse(EntityResult.EntityExist, "وضعیت های سفارش قبلا ایجاد شده است");

            var TrackingStatuses = Enumerable.Empty<TrackingStatus>();
            foreach (var orderStep in EnumExtension.GetArray<OrderStep>())
            {
                TrackingStatuses.Append(new TrackingStatus
                {
                    Step = orderStep,
                    DoneStatus = DoneStatus.Waiting,
                    DoneDate = null,
                    OrderId = create.OrderId,
                    BaseEntity = new BaseEntity(true),
                    SoftDelete = new SoftDelete(true),
                });
            }

            await _TrackingStatusRepository.Add(TrackingStatuses.ToList(),1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateTrackingStatusDto update)
        {
            TrackingStatus? TrackingStatus = await _TrackingStatusRepository.GetAsTracking(update.Id);
            
            if (TrackingStatus == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _TrackingStatusRepository.Update(update.ToModel(TrackingStatus), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            TrackingStatus? TrackingStatus = await _TrackingStatusRepository.GetAsTracking(delete);

            if (TrackingStatus == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _TrackingStatusRepository.SoftDelete(TrackingStatus, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
