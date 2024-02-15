using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPictureService : IService<Picture>
    {
        Task<PageDto<Picture , PictureListDto,long>> GetAll(FilterPictureDto filter , SortPictureDto sort , PagingDto paging);

        Task<ServiceResponse> Create(CreatePictureDto create);

        Task<ServiceResponse> Update(UpdatePictureDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
