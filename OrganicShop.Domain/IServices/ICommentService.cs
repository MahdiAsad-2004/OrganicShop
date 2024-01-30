using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface ICommentService
    {
        Task<PageDto<Comment,CommentListDto,long>> GetAll(FilterCommentDto filter, SortCommentDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateCommentDto create);

        Task<EntityResultUpdate> Update(UpdateCommentDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
