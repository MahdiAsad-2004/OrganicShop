using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;

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



        public async Task<PageDto<Tag , TagListDto,int>> GetAll(FilterTagDto filter , SortTagDto sort , PagingDto paging)
        {
            var query = _TagRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Title == true) query = query.OrderBy(o => o.Title);
            if (sort.Title == false) query = query.OrderByDescending(o => o.Title);

            #endregion

            PageDto<Tag, TagListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<TagListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateTagDto create)
        {
            Tag Tag = _Mapper.Map<Tag>(create);

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(create,a => nameof(a.Title)));

            await _TagRepository.Add(Tag,_AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateTagDto update)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(update.Id);
            
            if (Tag == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Title)));

            await _TagRepository.Update(_Mapper.Map<Tag>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(int delete)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(delete);

            if (Tag == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _TagRepository.SoftDelete(Tag, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
