using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICategoryService : IService<Category>
    {
        Task<PageDto<Category,CategoryListDto,int>> GetAll(FilterCategoryDto? filter = null, SortCategoryDto? sort = null,PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateCategoryDto create);

        Task<ServiceResponse> Update(UpdateCategoryDto update);
        
        Task<ServiceResponse> Delete( int id);
        
    }
}
