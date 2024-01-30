using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IPictureService
    {
        Task<PageDto<Picture , PictureListDto,long>> GetAll(FilterPictureDto filter , SortPictureDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreatePictureDto create);

        Task<EntityResultUpdate> Update(UpdatePictureDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
