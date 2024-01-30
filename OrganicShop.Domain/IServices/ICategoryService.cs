using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface ICategoryService
    {
        Task<PageDto<Category,CategoryListDto,int>> GetAll(FilterCategoryDto filter, SortCategoryDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateCategoryDto create);

        Task<EntityResultUpdate> Update(UpdateCategoryDto update);
        
        Task<EntityResultDelete> Delete( int id);
        
    }
}
