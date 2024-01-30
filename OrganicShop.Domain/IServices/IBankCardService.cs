using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IBankCardService
    {
        Task<PageDto<BankCard,BankCardListDto,long>> GetAll(FilterBankCardDto filter , SortBankCardDto sort, PagingDto paging);

        Task<EntityResultCreate> Create(CreateBankCardDto create);

        Task<EntityResultUpdate> Update(UpdateBankCardDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
