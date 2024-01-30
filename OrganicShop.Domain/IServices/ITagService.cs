using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface ITagService
    {
        Task<PageDto<Tag , TagListDto,int>> GetAll(FilterTagDto filter , SortTagDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreateTagDto create);

        Task<EntityResultUpdate> Update(UpdateTagDto update);
        
        Task<EntityResultDelete> Delete(int delete);
        
    }
}
