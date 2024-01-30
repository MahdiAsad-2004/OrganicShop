using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;


namespace OrganicShop.Domain.IServices
{
    public interface ITrackingDescriptionService
    {
        Task<PageDto<TrackingDescription , TrackingDescriptionListDto , long>> GetAll(FilterTrackingDescriptionDto filter , SortTrackingDescriptionDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreateTrackingDescriptionDto create);

        Task<EntityResultUpdate> Update(UpdateTrackingDescriptionDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
