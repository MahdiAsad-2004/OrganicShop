﻿using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class FilterProductDto : BaseFilterDto<Entities.Product, long>
    {
        public string? Title { get; set; }
        public string? Barcode { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public long? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public ProductSortType SortBy { get; set; } = ProductSortType.None;



        public IQueryable<Product> ApplySortType(IQueryable<Product> query)
        {

            switch (SortBy)
            {
                case ProductSortType.None:
                    break;

                case ProductSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case ProductSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case ProductSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case ProductSortType.Price:
                    query = query.OrderBy(a => a.Price);
                    break;

                case ProductSortType.PriceDesc:
                    query = query.OrderByDescending(a => a.Price);
                    break;

                case ProductSortType.Stock:
                    query = query.OrderBy(a => a.Stock);
                    break;

                case ProductSortType.StockDesc:
                    query = query.OrderByDescending(a => a.Stock);
                    break;

                case ProductSortType.SoldCount:
                    query = query.OrderBy(a => a.SoldCount);
                    break;

                case ProductSortType.SoldCountDesc:
                    query = query.OrderByDescending(a => a.SoldCount);
                    break;

                case ProductSortType.Discount:
                    query = query.OrderBy(a => a.UpdatedPrice);
                    break;

                case ProductSortType.DiscountDesc:
                    query = query.OrderByDescending(a => a.UpdatedPrice);
                    break;

            }

            return query;
        }
    }


}
