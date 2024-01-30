using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class TagService : ITagService
    {
        #region ctor

        private readonly ITagRepository _TagRepository;

        public TagService(ITagRepository TagRepository)
        {
            this._TagRepository = TagRepository;
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
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => a.ToListDto()).ToList();
            
            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateTagDto create)
        {
            Tag Tag = create.ToModel();

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(create.Title, StringComparison.OrdinalIgnoreCase)))
                return EntityResultCreate.EntityExist;

            await _TagRepository.Add(Tag,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateTagDto update)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(update.Id);
            
            if (Tag == null)
                return EntityResultUpdate.NotFound;

            if (await _TagRepository.GetQueryable().AnyAsync(a => a.Title.Contains(update.Title, StringComparison.OrdinalIgnoreCase) && a.Id != update.Id))
                return EntityResultUpdate.EntityExist;

            await _TagRepository.Update(update.ToModel(Tag), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(int delete)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(delete);

            if (Tag == null)
                return EntityResultDelete.NotFound;

            await _TagRepository.SoftDelete(Tag, 1);
            return EntityResultDelete.success;
        }
    }
}
