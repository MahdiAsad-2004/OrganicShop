using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IFaqService
    {
        Task<PageDto<Faq,FaqListDto,byte>> GetAll(FilterFaqDto filter, SortFaqDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateFaqDto create);

        Task<EntityResultUpdate> Update(UpdateFaqDto update);
        
        Task<EntityResultDelete> Delete(byte delete);
        
    }
}
