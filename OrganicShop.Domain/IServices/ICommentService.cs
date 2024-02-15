using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICommentService : IService<Comment>
    {
        Task<PageDto<Comment,CommentListDto,long>> GetAll(FilterCommentDto filter, SortCommentDto sort,PagingDto paging);

        Task<ServiceResponse> Create(CreateCommentDto create);

        Task<ServiceResponse> Update(UpdateCommentDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
