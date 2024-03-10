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
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICommentRepository _CommentRepository;

        public CommentService(IApplicationUserProvider provider,IMapper mapper,ICommentRepository CommentRepository) : base(provider)
        {
            _Mapper = mapper;
            this._CommentRepository = CommentRepository;
        }

        #endregion


        public async Task<PageDto<Comment, CommentListDto, long>> GetAll(FilterCommentDto? filter = null, SortCommentDto? sort = null, PagingDto? paging = null)
        {
            var query = _CommentRepository.GetQueryable();

            if (filter == null) filter = new FilterCommentDto();
            if (sort == null) sort = new SortCommentDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Status != null)
                query = query.Where(q => q.Status == filter.Status);

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Rate == SortOrder.Ascending) query = query.OrderBy(o => o.Rate);
            if (sort.Rate == SortOrder.Descending) query = query.OrderByDescending(o => o.Rate);

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
            await _CommentRepository.Add(Comment,_AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateCommentDto update)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(update.Id);
            
            if (Comment == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CommentRepository.Update(_Mapper.Map<Comment>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(delete);

            if (Comment == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _CommentRepository.SoftDelete(Comment, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }
    }
}
