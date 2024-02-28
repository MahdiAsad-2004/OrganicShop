using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.BaketDtos;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class BasketService : IBasketService
    {
        #region ctor

        private readonly IBasketRepository _BasketRepository;
        public Message<Basket> _Message { init; get; } = new Message<Basket>();

        public BasketService(IBasketRepository BasketRepository)
        {
            _BasketRepository = BasketRepository;
        }

        #endregion



        public async Task<PageDto<Basket, BasketListDto, long>> GetAll(FilterBasketDto filter, SortBasketDto sort, PagingDto paging)
        {
            var query = _BasketRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.TotalPrice == true) query = query.OrderBy(o => o.TotalPrice);
            if (sort.TotalPrice == false) query = query.OrderByDescending(o => o.TotalPrice);

            #endregion

            PageDto<Basket, BasketListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);


            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateBasketDto create)
        {
            if (await _BasketRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 2)
                return new ServiceResponse(EntityResult.MaxCreate, _Message.MaxCreate(2));

            Basket Basket = create.ToModel();

            await _BasketRepository.Add(Basket,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateBasketDto update)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(update.Id);
            
            if (Basket == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _BasketRepository.Update(update.ToModel(Basket), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(delete);

            if (Basket == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _BasketRepository.SoftDelete(Basket, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }




    }
}
