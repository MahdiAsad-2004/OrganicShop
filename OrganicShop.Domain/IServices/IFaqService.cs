﻿using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IFaqService : IService<Faq>
    {
        Task<PageDto<Faq,FaqListDto,byte>> GetAll(FilterFaqDto? filter = null, SortFaqDto? sort = null,PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateFaqDto create);

        Task<ServiceResponse> Update(UpdateFaqDto update);
        
        Task<ServiceResponse> Delete(byte delete);
        
    }
}
