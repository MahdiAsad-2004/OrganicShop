using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IServices
{
    public interface IService<Entity> where Entity : IAggregateRoot
    {
        //CurrentUser _User { init; }
        Message<Entity> _Message { get; }
    }
}
