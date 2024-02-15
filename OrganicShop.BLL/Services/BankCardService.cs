using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class BankCardService : IBankCardService
    {
        #region ctor

        private readonly IBankCardRepository _BankCardRepository;
        public Message<BankCard> _Message { init; get; }

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
            pageDto.Pager = pageDto.SetPager(query, paging);


            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateBankCardDto create)
        {
            if (await _BankCardRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 8)
                return new ServiceResponse(EntityResult.MaxCreate , _Message.MaxCreate(8));

            BankCard BankCard = create.ToModel();
            await _BankCardRepository.Add(BankCard, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }

            

        public async Task<ServiceResponse> Update(UpdateBankCardDto update)
        {
            BankCard? BankCard = await _BankCardRepository.GetAsTracking(update.Id);

            if (BankCard == null)
                return new ServiceResponse(EntityResult.Success, _Message.NotFound());

            if (BankCard.UserId != update.UserId)
                return new ServiceResponse(EntityResult.Success, _Message.NoAccess());

            await _BankCardRepository.Update(update.ToModel(BankCard), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {

            BankCard? BankCard = await _BankCardRepository.GetAsTracking(delete);

            if (BankCard == null)
                return new ServiceResponse(EntityResult.Success, _Message.NotFound());

            await _BankCardRepository.SoftDelete(BankCard, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
