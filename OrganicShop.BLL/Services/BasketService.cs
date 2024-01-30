using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.BaketDtos;

namespace OrganicShop.BLL.Services
{
    public class BasketService : IBasketService
    {
        #region ctor

        private readonly IBasketRepository _BasketRepository;

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

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateBasketDto create)
        {
            if (await _BasketRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() >= 2)
                return EntityResultCreate.MaxCreate;

            Basket Basket = create.ToModel();

            await _BasketRepository.Add(Basket,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateBasketDto update)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(update.Id);
            
            if (Basket == null)
                return EntityResultUpdate.NotFound;

            await _BasketRepository.Update(update.ToModel(Basket), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {
            Basket? Basket = await _BasketRepository.GetAsTracking(delete);

            if (Basket == null)
                return EntityResultDelete.NotFound;

            await _BasketRepository.SoftDelete(Basket, 1);
            return EntityResultDelete.success;
        }

 
        

    }
}
