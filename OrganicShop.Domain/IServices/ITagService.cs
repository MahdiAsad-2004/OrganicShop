using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ITagService : IService<Tag>
    {
        Task<PageDto<Tag , TagListDto,int>> GetAll(FilterTagDto? filter = null , SortTagDto? sort = null , PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateTagDto create);

        Task<ServiceResponse> Update(UpdateTagDto update);
        
        Task<ServiceResponse> Delete(int delete);
        
    }
}
