using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.CoProductDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class CoProductService : ICoProductService
    {
        #region ctor

        private readonly ICoProductRepository _CoProductRepository;
        private readonly IBasketRepository _BasketRepository;
        public Message<CoProduct> _Message { init; get; }

        public CoProductService(ICoProductRepository CoProductRepository, IBasketRepository basketRepository)
        {
            _CoProductRepository = CoProductRepository;
            _BasketRepository = basketRepository;
        }

        #endregion


        public async Task<PageDto<CoProduct, CoProductListDto, long>> GetAll(FilterCoProductDto filter, SortCoProductDto sort, PagingDto paging)
        {
            var query = _CoProductRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId > 0)
                query = query.Where(q => q.ProductId == filter.ProductId);

            if (filter.BasketId > 0)
                query = query.Where(q => q.BasketId == filter.BasketId);

            if (filter.OrderId > 0)
                query = query.Where(q => q.OrderId == filter.OrderId);

            if (filter.IsOrdered != null)
                query = query.Where(q => q.IsOrdered == filter.IsOrdered.Value);

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Price == true) query = query.OrderBy(o => o.Price);
            if (sort.Price == false) query = query.OrderByDescending(o => o.Price);

            if (sort.Count == true) query = query.OrderBy(o => o.Count);
            if (sort.Count == false) query = query.OrderByDescending(o => o.Count);

            #endregion

            PageDto<CoProduct, CoProductListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateCoProductDto create)
        {
            CoProduct? CoProduct = new();

            CoProduct = await _CoProductRepository.GetQueryable()
                .AsTracking()
                .Include(a => a.Product)
                .FirstOrDefaultAsync(a => a.ProductId == create.ProductId && a.BasketId == create.BasketId);
            if (CoProduct != null)
            {
                CoProduct.Count += create.Count;
                if (CoProduct.Count > CoProduct.Product.Stock)
                {
                    CoProduct.Count = CoProduct.Product.Stock; ;
                }
                CoProduct.IsOrdered = false;
                await _CoProductRepository.Update(CoProduct, 1);
            }
            else
            {
                CoProduct = create.ToModel();
                CoProduct.IsOrdered = false;
                await _CoProductRepository.Add(CoProduct, 1);


            }

            #region update basket

            var basket = await _BasketRepository.GetQueryable()
                .Include(a => a.CoProducts)
                .AsTracking()
                .FirstAsync(a => a.Id == create.BasketId);
            basket.TotalPrice = 0;
            foreach (var coP in basket.CoProducts)
            {
                basket.TotalPrice += coP.UpdatedPrice == null ? coP.Price : coP.UpdatedPrice.Value;
            }
            await _BasketRepository.Update(basket, 1);

            #endregion

            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateCoProductDto update)
        {
            CoProduct? CoProduct = await _CoProductRepository.GetAsTracking(update.Id);

            if (CoProduct == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            if (update.OrderId != null && update.BasketId == null)
            {
                update.IsOrdered = true;
            }
            else if (update.BasketId != null && update.OrderId == null)
            {
                update.IsOrdered = false;
            }
            else
            {
                throw new Exception("Change CoProduct Basket And Order State Exception");
            }
            await _CoProductRepository.Update(update.ToModel(CoProduct), 1);


            #region update basket

            var basket = await _BasketRepository.GetQueryable()
               .Include(a => a.CoProducts)
               .AsTracking()
               .FirstAsync(a => a.Id == update.BasketId);
            basket.TotalPrice = 0;
            foreach (var coP in basket.CoProducts)
            {
                basket.TotalPrice += coP.UpdatedPrice == null ? coP.Price : coP.UpdatedPrice.Value;
            }
            await _BasketRepository.Update(basket, 1);

            #endregion


            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long id)
        {

            CoProduct? CoProduct = await _CoProductRepository.GetAsTracking(id);

            if (CoProduct == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            CoProduct.BasketId = null;

            await _CoProductRepository.SoftDelete(CoProduct, 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
