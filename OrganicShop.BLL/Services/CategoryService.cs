using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CategoryDtos;

namespace OrganicShop.BLL.Services
{

    public class CategoryService : ICategoryService
    {
        #region ctor

        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        #endregion


        public async Task<PageDto<Category,CategoryListDto,int>> GetAll(FilterCategoryDto filter, SortCategoryDto sort,PagingDto paging)
        {
            var query = _CategoryRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.EnTitle != null)
                query = query.Where(q => EF.Functions.Like(q.EnTitle, $"%{filter.EnTitle}%"));

            if (filter.Type != null)
                query = query.Where(q => q.Type == filter.Type);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Title == true) query = query.OrderBy(o => o.Title);
            if (sort.Title == false) query = query.OrderByDescending(o => o.Title);

            #endregion

            PageDto<Category, CategoryListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateCategoryDto create)
        {
            if (_CategoryRepository.GetQueryable().Any(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
                return EntityResultCreate.EntityExist;

            if (_CategoryRepository.GetQueryable().Any(a => a.EnTitle.Contains(create.EnTitle, StringComparison.OrdinalIgnoreCase)))
                return EntityResultCreate.EntityExist;

            Category Category = create.ToModel();
            await _CategoryRepository.Add(Category, 1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateCategoryDto update)
        {
            if (_CategoryRepository.GetQueryable().Any(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return EntityResultUpdate.EntityExist;

            if (_CategoryRepository.GetQueryable().Any(a => a.EnTitle.Contains(update.EnTitle, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return EntityResultUpdate.EntityExist;

            Category? Category = await _CategoryRepository.GetAsTracking(update.Id);

            if (Category == null)
                return EntityResultUpdate.NotFound;

            await _CategoryRepository.Update(update.ToModel(Category), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(int id)
        {
            Category? Category = await _CategoryRepository.GetAsTracking(id);

            if (Category == null)
                return EntityResultDelete.NotFound;

            await _CategoryRepository.SoftDelete(Category, 1);
            return EntityResultDelete.success;
        }
    }
}
