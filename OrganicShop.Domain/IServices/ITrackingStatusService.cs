using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface ITrackingStatusService
    {
        Task<PageDto<TrackingStatus , TrackingStatusListDto , long>> GetAll(FilterTrackingStatusDto filter , SortTrackingStatusDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreateTrackingStatusDto create);

        Task<EntityResultUpdate> Update(UpdateTrackingStatusDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
