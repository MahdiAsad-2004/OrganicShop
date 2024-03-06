using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Page
{
    public class PageDto<Entity , ListDto , key> where Entity : class where ListDto : BaseListDto<key> where key : struct
    {
        public List<ListDto> List { get; set; } = new List<ListDto>();
        public Pager<Entity> Pager { get; set; }


       

        public IQueryable<Entity> SetPaging(IQueryable<Entity> query , PagingDto pagingDto)
        {
            //Pager = new Pager<Entity>(pagingDto.PageNumber, pagingDto.PageItemsCount, query);
            return query.Skip((pagingDto.PageNumber - 1) * pagingDto.PageItemsCount).Take(pagingDto.PageItemsCount);
        }

        public Pager<Entity> SetPager(IQueryable<Entity> query, PagingDto pagingDto)
        {
            return new Pager<Entity>(pagingDto.PageNumber, pagingDto.PageItemsCount, query);
        }



        //public void SetPager(int allItemsCount)
        //{
        //    Pager = new Pager<Entity>(PageNumber, PageItemsCount, allItemsCount);
        //}

    }
}
