﻿using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface IBasketRepository : IRepository,
        IReadRepository<Basket,long>,
        IWriteRepository<Basket,long>
    {

    }
}
