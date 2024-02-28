﻿using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{

    public class CategoryService : ICategoryService
    {
        #region ctor

        private readonly ICategoryRepository _CategoryRepository;
        public Message<Category> _Message { init; get; } = new Message<Category>();

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
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateCategoryDto create)
        {
            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(create,a => nameof(a.Title)));

            if (_CategoryRepository.GetQueryable().Any(a => a.EnTitle.Contains(create.EnTitle, StringComparison.OrdinalIgnoreCase)))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(create, a => nameof(a.EnTitle)));

            Category = create.ToModel();
            await _CategoryRepository.Add(Category, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateCategoryDto update)
        {
            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Title)));

            if (_CategoryRepository.GetQueryable().Any(a => a.EnTitle.Contains(update.EnTitle, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Title)));

            Category = await _CategoryRepository.GetAsTracking(update.Id);

            if (Category == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CategoryRepository.Update(update.ToModel(Category), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Delete(int id)
        {
            Category? Category = await _CategoryRepository.GetAsTracking(id);

            if (Category == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CategoryRepository.SoftDelete(Category, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
