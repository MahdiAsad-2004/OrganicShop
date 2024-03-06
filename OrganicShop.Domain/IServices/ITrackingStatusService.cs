﻿using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ITrackingStatusService : IService<TrackingStatus>
    {
        Task<PageDto<TrackingStatus,TrackingStatusListDto,long>> GetAll(FilterTrackingStatusDto? filter = null
            , SortTrackingStatusDto? sort = null , PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateTrackingStatusDto create);

        Task<ServiceResponse> Update(UpdateTrackingStatusDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
