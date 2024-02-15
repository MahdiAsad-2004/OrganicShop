﻿using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IBankCardService : IService<BankCard>
    {
        Task<PageDto<BankCard,BankCardListDto,long>> GetAll(FilterBankCardDto filter , SortBankCardDto sort, PagingDto paging);

        Task<ServiceResponse> Create(CreateBankCardDto create);

        Task<ServiceResponse> Update(UpdateBankCardDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
