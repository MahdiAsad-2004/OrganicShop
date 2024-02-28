using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class TrackingDescriptionService : ITrackingDescriptionService
    {
        #region ctor

        private readonly ITrackingDescriptionRepository _TrackingDescriptionRepository;
        private readonly IOrderRepository _OrderRepository;
        public Message<TrackingDescription> _Message { init; get; } = new Message<TrackingDescription>();

        public TrackingDescriptionService(ITrackingDescriptionRepository TrackingDescriptionRepository,IOrderRepository orderRepository)
        {
            _TrackingDescriptionRepository = TrackingDescriptionRepository;
            _OrderRepository = orderRepository;
        }

        #endregion



        public async Task<PageDto<TrackingDescription,TrackingDescriptionListDto,long>> GetAll(FilterTrackingDescriptionDto filter , SortTrackingDescriptionDto sort , PagingDto paging)
        {
            var query = _TrackingDescriptionRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.StartDate != null)
                query = query.Where(q => q.Date >= filter.StartDate);

            if (filter.EndDate != null)
                query = query.Where(q => q.Date <= filter.EndDate);

            if (filter.OrderId > 0)
                query = query.Where(q => q.OrderId == filter.OrderId);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Title == true) query = query.OrderBy(o => o.Title);
            if (sort.Title == false) query = query.OrderByDescending(o => o.Title);

            if (sort.Date == true) query = query.OrderBy(o => o.Date);
            if (sort.Date == false) query = query.OrderByDescending(o => o.Date);

            #endregion

            PageDto<TrackingDescription, TrackingDescriptionListDto,long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateTrackingDescriptionDto create)
        {
            TrackingDescription TrackingDescription = create.ToModel();

            #region relation

            if (await _OrderRepository.GetQueryable().AnyAsync(a => a.Id == create.OrderId) == false)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound(typeof(Order)));

            #endregion

            await _TrackingDescriptionRepository.Add(TrackingDescription,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateTrackingDescriptionDto update)
        {
            TrackingDescription? TrackingDescription = await _TrackingDescriptionRepository.GetAsTracking(update.Id);
            
            if (TrackingDescription == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            #region relation

            if (await _OrderRepository.GetQueryable().AnyAsync(a => a.Id == update.OrderId) == false)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound(typeof(Order)));

            #endregion

            await _TrackingDescriptionRepository.Update(update.ToModel(TrackingDescription), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            TrackingDescription? TrackingDescription = await _TrackingDescriptionRepository.GetAsTracking(delete);

            if (TrackingDescription == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound())      ;

            await _TrackingDescriptionRepository.SoftDelete(TrackingDescription, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
