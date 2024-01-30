﻿using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    public class Permission : EntityId<byte>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public byte? ParentId { get; set; }



        public Permission? Parent { get; set; }
        public ICollection<Permission>? Subs { get; set; }
        public ICollection<PermissionUsers>? PermissionUsers { get; set; }
    }
}
