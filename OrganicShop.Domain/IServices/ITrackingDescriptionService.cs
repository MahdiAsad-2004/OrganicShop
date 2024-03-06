﻿using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;


namespace OrganicShop.Domain.IServices
{
    public interface ITrackingDescriptionService : IService<TrackingDescription>
    {
        Task<PageDto<TrackingDescription , TrackingDescriptionListDto , long>> GetAll(FilterTrackingDescriptionDto? filter = null 
            , SortTrackingDescriptionDto? sort = null , PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateTrackingDescriptionDto create);

        Task<ServiceResponse> Update(UpdateTrackingDescriptionDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
