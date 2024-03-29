﻿using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Services
{
    public class TagService : Service<Tag>, ITagService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ITagRepository _TagRepository;

        public TagService(IApplicationUserProvider provider,IMapper mapper,ITagRepository TagRepository) : base(provider)
        {
            _Mapper = mapper;
            _TagRepository = TagRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Tag, TagListDto, int>>> GetAll(FilterTagDto? filter = null,PagingDto? paging = null)
        {
            var query = _TagRepository.GetQueryable();

            if (filter == null) filter = new FilterTagDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Tag, TagListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<TagListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Tag, TagListDto, int>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateTagDto create)
        {
            Tag Tag = _Mapper.Map<Tag>(create);

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create,a => nameof(a.Title)));

            await _TagRepository.Add(Tag,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateTagDto update)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(update.Id);
            
            if (Tag == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            await _TagRepository.Update(_Mapper.Map<Tag>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(delete);

            if (Tag == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _TagRepository.SoftDelete(Tag, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}
