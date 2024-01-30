using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CommentDtos;

namespace OrganicShop.BLL.Services
{
    public class CommentService : ICommentService
    {
        #region ctor

        private readonly ICommentRepository _CommentRepository;

        public CommentService(ICommentRepository CommentRepository)
        {
            this._CommentRepository = CommentRepository;
        }

        #endregion


        public async Task<PageDto<Comment, CommentListDto, long>> GetAll(FilterCommentDto filter, SortCommentDto sort, PagingDto paging)
        {
            var query = _CommentRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Status != null)
                query = query.Where(q => q.Status == filter.Status);

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Rate == true) query = query.OrderBy(o => o.Rate);
            if (sort.Rate == false) query = query.OrderByDescending(o => o.Rate);

            #endregion

            PageDto<Comment, CommentListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateCommentDto create)
        {
            Comment Comment = create.ToModel();
            Comment.Status = CommentStatus.Unread;
            await _CommentRepository.Add(Comment,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateCommentDto update)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(update.Id);
            
            if (Comment == null)
                return EntityResultUpdate.NotFound;

            await _CommentRepository.Update(update.ToModel(Comment), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(delete);

            if (Comment == null)
                return EntityResultDelete.NotFound;

            await _CommentRepository.SoftDelete(Comment, 1);
            return EntityResultDelete.success;
        }
    }
}
