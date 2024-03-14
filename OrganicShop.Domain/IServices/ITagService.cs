using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ITagService : IService<Tag>
    {
        Task<ServiceResponse<PageDto<Tag, TagListDto, int>>> GetAll(FilterTagDto? filter = null , SortTagDto? sort = null , PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateTagDto create);

        Task<ServiceResponse<Empty>> Update(UpdateTagDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);
        
    }
}
