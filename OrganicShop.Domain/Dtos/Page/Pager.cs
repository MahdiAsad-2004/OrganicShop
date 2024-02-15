using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Page
{
    public class Pager<Entity>
    {
        public int PageShowAfterAndBeforeCurrent { get; set; }
        public int AllItemsCount { get; private set; }
        public int PageItemNumberStart { get; private set; }
        public int PageItemNumberEnd { get; private set; }
        public int LastPageNumber { get; private set; }

        public string PageStatus()
        {
            //return $"نمایش از {PageItemNumberStart} تا {PageItemNumberEnd} از {AllItemsCount} مورد";
            return $"Sohwing page {PageItemNumberStart} to {PageItemNumberEnd} items from {AllItemsCount} items";
        }


        public Pager(int PageNumber, int PageItemCount, IQueryable<Entity> query)
        {
            AllItemsCount = query.Count();
            PageItemNumberEnd = AllItemsCount > PageItemCount ? (PageItemCount * PageNumber) : AllItemsCount;
            PageItemNumberStart = ((PageNumber - 1) * PageItemCount) + 1;
            LastPageNumber = AllItemsCount % PageItemCount == 0 ? (AllItemsCount / PageItemCount) : (AllItemsCount / PageItemCount) + 1;
        }
        //public Pager(int PageNumber, int PageItemCount, int AllItemsCount)
        //{
        //    this.AllItemsCount = AllItemsCount;
        //    PageItemNumberEnd = AllItemsCount > PageItemCount ? (PageItemCount * PageNumber) : AllItemsCount;
        //    PageItemNumberStart = (PageNumber - 1) * PageItemCount + 1;
        //    LastPageNumber = AllItemsCount % PageItemCount == 0 ? (AllItemsCount / PageItemCount) : (AllItemsCount / PageItemCount) + 1;
        //}
    }
}
