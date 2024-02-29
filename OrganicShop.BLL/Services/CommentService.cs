using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;

namespace OrganicShop.BLL.Services
{
    public class CommentService : ICommentService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICommentRepository _CommentRepository;
        public Message<Comment> _Message { init; get; } = new Message<Comment>();

        public CommentService(IMapper mapper,ICommentRepository CommentRepository)
        {
            _Mapper = mapper;
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
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CommentListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateCommentDto create)
        {
            Comment Comment = _Mapper.Map<Comment>(create);
            Comment.Status = CommentStatus.Unread;
            await _CommentRepository.Add(Comment,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateCommentDto update)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(update.Id);
            
            if (Comment == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CommentRepository.Update(_Mapper.Map<Comment>(update), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(delete);

            if (Comment == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CommentRepository.SoftDelete(Comment, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }
    }
}
