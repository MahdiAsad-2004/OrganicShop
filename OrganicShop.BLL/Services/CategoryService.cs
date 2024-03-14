using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.BLL.Services
{

    public class CategoryService : Service<Category>, ICategoryService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(IApplicationUserProvider provider, IMapper mapper, ICategoryRepository CategoryRepository) : base(provider)
        {
            _Mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Category, CategoryListDto, int>>> GetAll
            (FilterCategoryDto? filter = null, SortCategoryDto? sort = null, PagingDto? paging = null)
        {
            var query = _CategoryRepository.GetQueryable();

            if (filter == null) filter = new FilterCategoryDto();
            if (sort == null) sort = new SortCategoryDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.Type != null)
                query = query.Where(q => q.Type == filter.Type);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Title == SortOrder.Ascending) query = query.OrderBy(o => o.Title);
            if (sort.Title == SortOrder.Descending) query = query.OrderByDescending(o => o.Title);

            #endregion

            PageDto<Category, CategoryListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CategoryListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Category, CategoryListDto, int>>(ResponseResult.Success, "", pageDto);
        }


        public async Task<ServiceResponse<UpdateCategoryDto>> Get(int Id)
        {
            var entity = await _CategoryRepository
                .GetAsNoTracking(Id);

            if (entity == null)
                return new ServiceResponse<UpdateCategoryDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<UpdateCategoryDto>(ResponseResult.Success, _Mapper.Map<UpdateCategoryDto>(entity));
        }



        public async Task<ServiceResponse<Empty>> Create(CreateCategoryDto create)
        {
            //HasPermission(a => a.Categories_Admin);

            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => EF.Functions.Like(a.Title, create.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Title)));

            Category = _Mapper.Map<Category>(create);

            //// Saving Image
            Category.Image = await create.ImageFile.SaveFile(PathExtensions.CategoryImage);

            await _CategoryRepository.Add(Category, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateCategoryDto update)
        {
            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            Category = await _CategoryRepository.GetAsTracking(update.Id);

            if (Category == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CategoryRepository.Update(_Mapper.Map<Category>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int id)
        {
            Category? Category = await _CategoryRepository.GetAsTracking(id);

            if (Category == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CategoryRepository.SoftDelete(Category, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }


        public async Task<ServiceResponse<List<ComboDto<Category>>>> GetCombos()
        {
              var comboDtos = _CategoryRepository
                .GetQueryable()
                .Select(a => _Mapper.Map<ComboDto<Category>>(a))
                .ToList();
            return new ServiceResponse<List<ComboDto<Category>>>(ResponseResult.Success, comboDtos);
        }
    }
}
