using OrganicShop.BLL.Providers;
using OrganicShop.Domain.Response;
using OrganicShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.IServices;
using System.Reflection;
using OrganicShop.Domain.SeedDatas;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public abstract class Service<Entity> : IService<Entity> where Entity : IAggregateRoot
    {
        public Message<Entity> _Message { get; init; } = new Message<Entity>();
        public IApplicationUserProvider _AppUserProvider { get; init; }
        
        private PermissionsSeed PermissionsSeed = new PermissionsSeed();

        public Service(IApplicationUserProvider applicationUserProvider)
        {
            _AppUserProvider = applicationUserProvider;
        }


        public bool HasPermission(Func<PermissionsSeed, byte> permissionId)
        {
            var Title = permissionId.Invoke(PermissionsSeed);
            return _AppUserProvider.User.PermissionIds.Any(a => a.Equals(permissionId));
        }




    }
}
