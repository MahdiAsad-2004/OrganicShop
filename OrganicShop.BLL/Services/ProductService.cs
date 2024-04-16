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
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.DiscountDtos;

namespace OrganicShop.BLL.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IProductRepository _ProductRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IDiscountProductsRepository _DiscountProductRepository;

        public ProductService(IApplicationUserProvider provider, IMapper mapper, IProductRepository ProductRepository, ICategoryRepository categoryRepository,
            IDiscountProductsRepository discountProductRepository, IPropertyRepository propertyRepository) : base(provider)
        {
            _Mapper = mapper;
            _ProductRepository = ProductRepository;
            _CategoryRepository = categoryRepository;
            _DiscountProductRepository = discountProductRepository;
            _PropertyRepository = propertyRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Product, ProductListDto, long>>> GetAll(FilterProductDto? filter = null, PagingDto? paging = null)
        {
            var query = _ProductRepository.GetQueryable()
                .Include(a => a.Pictures)
                .Include(a => a.Category)
                    .ThenInclude(a => a.DiscountCategories)
                        .ThenInclude(a => a.Discount)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .AsQueryable();

            if (filter == null) filter = new FilterProductDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId != null)
                query = query.Where(q => q.Id == filter.ProductId);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.MaxPrice != null)
                query = query.Where(q => q.Price <= filter.MaxPrice);

            if (filter.MinPrice != null)
                query = query.Where(q => q.Price >= filter.MinPrice);

            if (filter.CategoryId != null)
                query = query.Where(q => q.CategoryId.Equals(filter.CategoryId));
            

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Product, ProductListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ProductListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Product, ProductListDto, long>>(ResponseResult.Success, pageDto);
        }






        public async Task<ServiceResponse<UpdateProductDto>> Get(long Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateProductDto>(ResponseResult.NotFound, null);

            var product = await _ProductRepository.GetQueryable()
                .AsNoTracking()
                .Include(a => a.TagProducts)
                .Include(a => a.Properties)
                .Include(a => a.Pictures)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .FirstOrDefaultAsync(a => a.Id.Equals(Id));

            if (product != null)
                return new ServiceResponse<UpdateProductDto>(ResponseResult.Success, _Mapper.Map<UpdateProductDto>(product));

            return new ServiceResponse<UpdateProductDto>(ResponseResult.NotFound, null);
        }








        public async Task<ServiceResponse<Empty>> Create(CreateProductDto create)
        {
            Product Product = _Mapper.Map<Product>(create);

            #region discounts

            if (create.UpdatedPrice < create.Price)
            {
                var discount = new Discount
                {
                    Title = "Basic",
                    FixValue = create.Price - create.UpdatedPrice,
                    IsFixDiscount = true,
                    BaseEntity = new BaseEntity(true),
                    IsDefault = true,
                };

                if (create.DiscountCount > 0)
                    discount.Count = create.DiscountCount;

                Product.DiscountProducts = new List<DiscountProducts> { new DiscountProducts
                    {
                        Discount = discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    }
                };
            }

            #endregion

            #region pictures

            var pictures = new List<Picture>();
            var pictureMain = await create.MainImageFile.SavePictureAsync(PathExtensions.ProductImage);
            pictureMain.IsMain = true;
            pictures.Add(pictureMain);
            if (create.PictureFiles != null)
            {
                foreach (var pictureFile in create.PictureFiles)
                {
                    pictures.Add(await pictureFile.SavePictureAsync(PathExtensions.ProductImage));
                }
            }
            Product.Pictures = pictures;

            #endregion

            #region tags

            if (create.TagIds != null)
            {
                var tagProducts = new List<TagProducts>();
                foreach (var tagId in create.TagIds)
                {
                    tagProducts.Add(new TagProducts
                    {
                        TagId = tagId,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.TagProducts = tagProducts;
            }

            #endregion

            #region properties

            if(create.PropertiesDictionary != null)
            {
                Property? property = null;
                var properties = new List<Property>();
                foreach (var propertyDic in create.PropertiesDictionary)
                {
                    property = await _PropertyRepository.GetAsNoTracking(propertyDic.Key);
                    if (property == null)
                        return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Property)));

                    properties.Add(new Property
                    {
                        Title = property.Title,
                        Priority = property.Priority,
                        Value = propertyDic.Value,
                        IsBase = false,
                        BaseId = propertyDic.Key,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Properties = properties;
            }

            #endregion

            await _ProductRepository.Add(Product, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateProductDto update)
        {
            Product? Product = await _ProductRepository.GetQueryableTracking()
                .Include(a => a.TagProducts)
                .Include(a => a.Properties)
                .Include(a => a.Pictures)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .FirstOrDefaultAsync(a => a.Id.Equals(update.Id));

            if (Product == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            #region discounts

            Discount discount;
            DiscountProducts discountProduct;
            if (update.UpdatedPrice < update.Price)
            {
                if(update.DiscountId > 0)
                {
                    discountProduct = Product.DiscountProducts.First(a => a.DiscountId == update.DiscountId);
                    discountProduct.Discount.FixValue = update.UpdatedPrice;
                    discountProduct.Discount.BaseEntity.LastModified = DateTime.Now;
                    if (update.DiscountCount > 0)
                        discountProduct.Discount.Count = update.DiscountCount;
                }
                else
                {
                    discount = new Discount
                    {
                        Title = "Basic",
                        FixValue = update.Price - update.UpdatedPrice,
                        IsFixDiscount = true,
                        BaseEntity = new BaseEntity(true),
                        IsDefault = true,
                    };
                    discountProduct = new DiscountProducts
                    {
                        Discount = discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    };
                    Product.DiscountProducts.Add(discountProduct);
                }
                
            }

            #endregion

            #region pictures

            if (update.MainPictureFile != null)
            {
                Product.Pictures.First(a => a.IsMain).BaseEntity.IsDelete = true;
                var mainPicture = await update.MainPictureFile.SavePictureAsync(PathExtensions.ProductImage);
                mainPicture.IsMain = true;
                Product.Pictures.Add(mainPicture);
                // = await Product.Pictures.ToList().SaveAndUpdateMainPictureAsync(update.MainPictureFile, PathExtensions.ProductImage);
            }

            foreach (var picture in Product.Pictures.ExceptBy(update.OldPicturesDic.Keys,a => a.Id))
            {
                Product.Pictures.Remove(picture);   
            }

            if (update.NewPictureFiles != null)
            {
                var pictures = new List<Picture>();
                foreach (var file in update.NewPictureFiles)
                {
                    pictures.Add(await file.SavePictureAsync(PathExtensions.ProductImage));
                }
                Product.Pictures = pictures;
            }

            #endregion

            #region tags

            if(update.TagIds != null)
            {
                foreach (var tagId in update.TagIds.ExceptBy(Product.TagProducts.Select(a => a.TagId), a => a))
                {
                    Product.TagProducts.Add(new TagProducts
                    {
                        ProductId = update.Id,
                        TagId = tagId,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                foreach (var tag in Product.TagProducts.ExceptBy(update.TagIds, a => a.TagId))
                {
                    Product.TagProducts.Remove(tag);
                }
            }

            #endregion

            #region properties

            //foreach (var propertyDic in update.Properties.ExceptBy(Product.Properties.Select(a => a.Id), a => a.Value.Id))
            //{
            //    property = await _PropertyRepository.GetAsNoTracking(propertyDic.Key);
            //    if (property == null)
            //        return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Property)));

            //    Product.Properties.Add(new Property
            //    {
            //        ProductId = update.Id,
            //        Title = property.Title,
            //        Priority = property.Priority,
            //        Value = property.Value,
            //        IsBase = false,
            //        BaseEntity = new BaseEntity(true),
            //    });
            //}
            if(update.PropertiesDic != null)
            {
                Property? property = null;
                foreach (var propertyDic in update.PropertiesDic.Where(a => a.Value.Id > 0))
                {
                    property = await _PropertyRepository.GetAsNoTracking(propertyDic.Key);
                    if (property == null)
                        return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Property)));

                    Product.Properties.Add(new Property
                    {
                        ProductId = update.Id,
                        Title = property.Title,
                        Priority = property.Priority,
                        Value = property.Value,
                        IsBase = false,
                        BaseEntity = new BaseEntity(true),
                    });
                }


                foreach (var propperty in Product.Properties.ExceptBy(update.PropertiesDic.Select(a => a.Value.Id), a => a.Id))
                {
                    Product.Properties.Remove(propperty);
                }

                foreach (var propperty in Product.Properties.IntersectBy(update.PropertiesDic.Select(a => a.Value.Id), a => a.Id))
                {
                    propperty.Value = update.PropertiesDic[propperty.BaseId.Value].Value;
                }
            }

            #endregion

            await _ProductRepository.Update(_Mapper.Map(update , Product), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }




        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Product? Product = await _ProductRepository.GetAsTracking(delete);

            if (Product == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _ProductRepository.SoftDelete(Product, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos()
        {
            var comboDtos = _ProductRepository
              .GetQueryable()
              .Select(a => _Mapper.Map<ComboDto<Product>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Product>>>(ResponseResult.Success, comboDtos);
        }



        public async Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos(long[] productIds)
        {
            var comboDtos = _ProductRepository
              .GetQueryable()
              .Where(a => productIds.Contains(a.Id))
              .Select(a => _Mapper.Map<ComboDto<Product>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Product>>>(ResponseResult.Success, comboDtos);
        }

    }
}
