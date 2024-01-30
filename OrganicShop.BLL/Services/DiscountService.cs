using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class DiscountService : IDiscountService
    {
        #region ctor

        private readonly IDiscountRepository _DiscountRepository;
        private readonly IDiscountUsersRepository _DiscountUsersRepository;
        private readonly IDiscountProductsRepository _DiscountProductsRepository;

        public DiscountService(IDiscountRepository discountRepository, IDiscountUsersRepository discountUsersRepository, IDiscountProductsRepository discountProductsRepository)
        {
            _DiscountRepository = discountRepository;
            _DiscountUsersRepository = discountUsersRepository;
            _DiscountProductsRepository = discountProductsRepository;
        }

        #endregion



        public async Task<PageDto<Discount,DiscountListDto,int>> GetAll(FilterDiscountDto filter, SortDiscountDto sort , PagingDto paging)
        {
            var query = _DiscountRepository.GetQueryable()
                .Include(a => a.DiscountUsers)
                .AsQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
            {
                IQueryable<Discount> query1 = _DiscountUsersRepository.GetQueryable()
                    .Where(a => a.UserId == filter.UserId)
                    .Select(a => a.Discount)
                    .AsQueryable();
                query = query.IntersectBy(query1.Select(a => a.Id) , a => a.Id);
            }

            if (filter.ProductId > 0)
            {
                IQueryable<Discount> query2 = _DiscountProductsRepository.GetQueryable()
                    .Where(a => a.ProductId == filter.ProductId)
                    .Select(a => a.Discount)
                    .AsQueryable();
                query = query.IntersectBy(query2.Select(a => a.Id) , a => a.Id);
            }

            if (filter.IsDefault != null)
                query = query.Where(a => a.IsDefault == filter.IsDefault.Value);

            if (filter.IsPercent != null)
                query = query.Where(a => a.Percent != null);

            #endregion

            #region sort

            query = sort.ApplyBaseSort(query);

            if (sort.Count == true) query = query.OrderBy(o => o.Count);
            if (sort.Count == false) query = query.OrderByDescending(o => o.Count);

            if (sort.Percent == true) query = query.OrderBy(o => o.Percent);
            if (sort.Percent == false) query = query.OrderByDescending(o => o.Percent);

            if (sort.FixedValue == true) query = query.OrderBy(o => o.FixedValue);
            if (sort.FixedValue == false) query = query.OrderByDescending(o => o.FixedValue);

            #endregion


            PageDto<Discount, DiscountListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query,paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateDiscountDto create)
        {
            Discount Discount = create.ToModel();

            foreach (var id in create.UsersIds)
            {
                Discount.DiscountUsers.Add(new DiscountUsers
                {
                    UserId = id,
                    BaseEntity = new BaseEntity(true),
                    SoftDelete = new SoftDelete(true),
                });
            }
            foreach (var id in create.ProducsIds)
            {
                Discount.DiscountProducts.Add(new DiscountProducts
                {
                    ProductId = id,
                    BaseEntity = new BaseEntity(true),
                    SoftDelete = new SoftDelete(true),
                });
            }

            await _DiscountRepository.Add(Discount, 1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateDiscountDto update)
        {
            Discount? Discount = await _DiscountRepository.GetQueryable()
                .Include(a => a.DiscountUsers)
                .Include(a => a.DiscountProducts)
                .AsTracking()
                .FirstOrDefaultAsync(a => a.Id == update.Id);

            if (Discount == null)
                return EntityResultUpdate.NotFound;

            if (update.UsersIds.Any())
            {
                Discount.DiscountUsers.Clear();
                foreach (var id in update.UsersIds)
                {
                    Discount.DiscountUsers.Add(new DiscountUsers
                    {
                        DiscountId = update.Id,
                        UserId = id,
                        BaseEntity = new BaseEntity(true),
                        SoftDelete = new SoftDelete(true),
                    });
                }
            }

            if (update.ProducsIds.Any())
            {
                Discount.DiscountProducts.Clear();
                foreach (var id in update.ProducsIds)
                {
                    Discount.DiscountProducts.Add(new DiscountProducts
                    {
                        DiscountId = update.Id,
                        ProductId = id,
                        BaseEntity = new BaseEntity(true),
                        SoftDelete = new SoftDelete(true),
                    });
                }
            }

            await _DiscountRepository.Update(update.ToModel(Discount), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(int id)
        {

            Discount? Discount = await _DiscountRepository.GetAsTracking(id);

            if (Discount == null)
                return EntityResultDelete.NotFound;

            await _DiscountRepository.SoftDelete(Discount, 1);
            return EntityResultDelete.success;
        }
    }
}
