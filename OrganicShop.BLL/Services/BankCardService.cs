using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.BankCardDtos;

namespace OrganicShop.BLL.Services
{
    public class BankCardService : IBankCardService
    {
        #region ctor

        private readonly IBankCardRepository _BankCardRepository;

        public BankCardService(IBankCardRepository BankCardRepository)
        {
            this._BankCardRepository = BankCardRepository;
        }

        #endregion



        public async Task<PageDto<BankCard, BankCardListDto, long>> GetAll(FilterBankCardDto filter, SortBankCardDto sort, PagingDto paging)
        {
            var query = _BankCardRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            #endregion

            PageDto<BankCard, BankCardListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateBankCardDto create)
        {
            if (await _BankCardRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 8)
                return EntityResultCreate.MaxCreate;

            BankCard BankCard = create.ToModel();
            await _BankCardRepository.Add(BankCard, 1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateBankCardDto update)
        {
            BankCard? BankCard = await _BankCardRepository.GetAsTracking(update.Id);

            if (BankCard == null)
                return EntityResultUpdate.NotFound;

            if (BankCard.UserId != update.UserId)
                return EntityResultUpdate.NoAccess;

            await _BankCardRepository.Update(update.ToModel(BankCard), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {

            BankCard? BankCard = await _BankCardRepository.GetAsTracking(delete);

            if (BankCard == null)
                return EntityResultDelete.NotFound;

            await _BankCardRepository.SoftDelete(BankCard, 1);
            return EntityResultDelete.success;
        }
    }
}
