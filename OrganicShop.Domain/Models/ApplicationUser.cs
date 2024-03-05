﻿using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.Models
{
    public class ApplicationUser
    {
        public long Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
        public IEnumerable<byte> PermissionIds { get; set; } = Enumerable.Empty<byte>();    

    }
}