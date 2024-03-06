using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IProductRepository _ProductRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IDiscountProductsRepository _DiscountProductRepository;

        public ProductService(IApplicationUserProvider provider,IMapper mapper,IProductRepository ProductRepository, ICategoryRepository categoryRepository,
            IDiscountProductsRepository discountProductRepository) : base(provider)
        {
            _Mapper = mapper;
            _ProductRepository = ProductRepository;
            _CategoryRepository = categoryRepository;
            _DiscountProductRepository = discountProductRepository;
        }

        #endregion



        public async Task<PageDto<Product, ProductListDto, long>> GetAll(FilterProductDto? filter = null, SortProductDto? sort = null, PagingDto? paging = null)
        {
            var query = _ProductRepository.GetQueryable()
                .Include(a => a.Category)
                .AsQueryable();

            if (filter == null) filter = new FilterProductDto();
            if (sort == null) sort = new SortProductDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId != null)
                query = query.Where(q => q.Id == filter.ProductId);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(filter.Title, $"%{q.Title}"));

            if (filter.Barcode != null)
                query = query.Where(q => EF.Functions.Like(filter.Barcode, $"%{q.Barcode}"));

            if (filter.MaxPrice != null)
                query = query.Where(q => q.Price <= filter.MaxPrice);

            if (filter.MinPrice != null)
                query = query.Where(q => q.Price >= filter.MinPrice);

            if (filter.CategoryId != null)
            {
                var category = _CategoryRepository.GetQueryable().Include(a => a.Products).FirstOrDefault(a => a.Id == filter.CategoryId);
                if (category != null)
                {
                    if (category.Products != null)
                    {
                        query = category.Products.AsQueryable().IntersectBy(query.Select(a => a.Id), i => i.Id);
                    }
                }
            }

            #endregion

            #region sort

            if (sort.Title == true) query = query.OrderBy(o => o.Title);
            if (sort.Title == false) query = query.OrderByDescending(o => o.Title);

            if (sort.Price == true) query = query.OrderBy(o => o.Price);
            if (sort.Price == false) query = query.OrderByDescending(o => o.Price);

            if (sort.SoldCount == true) query = query.OrderBy(o => o.SoldCount);
            if (sort.SoldCount == false) query = query.OrderByDescending(o => o.SoldCount);

            if (sort.Discount == true) query = query.OrderByDescending(a => a.Price - a.UpdatedPrice);

            #endregion


            PageDto<Product, ProductListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ProductListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateProductDto create)
        {
            Product Product = _Mapper.Map<Product>(create);
            Product.UpdatedPrice = null;

            #region discounts

            if (create.UpdatedPrice < create.Price)
            {
                var discount = new Discount
                {
                    FixedValue = create.Price - create.UpdatedPrice,
                    BaseEntity = new BaseEntity(true),
                    IsDefault = true,
                };

                if(create.DiscountCount > 0)
                    discount.Count = create.DiscountCount;
                
                Product.DiscountProducts = new List<DiscountProducts> { new DiscountProducts
                    {
                        Discount = discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    }
                };
                Product.UpdatedPrice = discount.ApplyDiscount(Product.Price);
            }

            #endregion

            #region pictures

            if (create.PictureFiles != null)
            {
                var pictures = Enumerable.Empty<Picture>();
                foreach (var file in create.PictureFiles)
                {
                    pictures.Append(_Mapper.Map<Picture>(file));
                }
                Product.Pictures = pictures.ToList();
            }

            #endregion

            #region tags

            if (create.Tags != null)
            {
                var tags = Enumerable.Empty<Tag>();
                foreach (var str in create.Tags)
                {
                    tags.Append(new Tag
                    {
                        Title = str,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Tags = tags.ToList();
            }

            #endregion

            #region properties

            if (create.Properties != null)
            {
                var properties = Enumerable.Empty<Property>();
                foreach (var property in create.Properties)
                {
                    properties.Append(new Property
                    {
                        Title = property.Key,
                        Value = property.Value,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Properties = properties.ToList();
            }

            #endregion

            await _ProductRepository.Add(Product, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateProductDto update)
        {
            Product? Product = await _ProductRepository.GetAsTracking(update.Id);

            if (Product == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            #region discounts

            if (update.Discount.FixedValue != null || update.Discount.Percent != null)
            {
                Product.DiscountProducts = new List<DiscountProducts> { new DiscountProducts
                    {
                        Discount = update.Discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    } 
                };
                Product.UpdatedPrice = update.Discount.ApplyDiscount(Product.Price);
            }

            #endregion

            #region pictures

            if (update.PictureFiles != null)
            {
                var pictures = Enumerable.Empty<Picture>();
                foreach (var file in update.PictureFiles)
                {
                    pictures.Append(_Mapper.Map<Picture>(file));
                }
                Product.Pictures = pictures.ToList();
            }

            #endregion

            #region tags

            if (update.Tags != null)
            {
                var tags = Enumerable.Empty<Tag>();
                foreach (var str in update.Tags)
                {
                    tags.Append(new Tag
                    {
                        Title = str,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Tags = tags.ToList();
            }

            #endregion

            #region properties

            if (update.Properties != null)
            {
                var properties = Enumerable.Empty<Property>();
                foreach (var property in update.Properties)
                {
                    properties.Append(new Property
                    {
                        Title = property.Key,
                        Value = property.Value,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Properties = properties.ToList();
            }

            #endregion

            await _ProductRepository.Update(_Mapper.Map<Product>(update), _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            Product? Product = await _ProductRepository.GetAsTracking(delete);

            if (Product == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _ProductRepository.SoftDelete(Product, _AppUserProvider.User.Id);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }
    }
}
