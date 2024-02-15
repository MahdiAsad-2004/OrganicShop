using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Base
{
    public class BaseFilterDto<Entity,Key> : BaseDto  where Entity : EntityId<Key> where Key : struct
    {
        //public DeleteFilter DeleteFilter { get; set; } = DeleteFilter.NotDeleted;
        public IsActiveFilter ActiveFilter { get; set; } = IsActiveFilter.Active;


        public IQueryable<Entity> ApplyBaseFilters(IQueryable<Entity> query)
        {
            //switch (DeleteFilter)
            //{
            //    case DeleteFilter.All:
            //        //query = query.Where(a => a.SoftDelete.IsDelete == true || a.SoftDelete.IsDelete == false);
            //        break;

            //    case DeleteFilter.Deleted:
            //        query = query.Where(a => a.SoftDelete.IsDelete == true);
            //        break;

            //    case DeleteFilter.NotDeleted:
            //        query = query.Where(a => a.SoftDelete.IsDelete == false);
            //        break;
            //}

            switch (ActiveFilter)
            {
                case IsActiveFilter.Active:
                    query = query.Where(a => a.BaseEntity.IsActive == true);
                    break;

                case IsActiveFilter.NotActive:
                    query = query.Where(a => a.BaseEntity.IsActive == false);
                    break;
            }

            return query;
        }

    }
}
