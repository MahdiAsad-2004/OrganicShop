﻿using Microsoft.EntityFrameworkCore;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public class PermissionUsersRepository : CrudRepository<PermissionUsers, int>, IPermissionUsersRepository
    {
    }


}
