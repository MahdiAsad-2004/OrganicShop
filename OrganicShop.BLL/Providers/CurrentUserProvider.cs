using OrganicShop.BLL.Extensions;
using OrganicShop.DAL;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Models;

namespace OrganicShop.BLL.Providers
{
    public class CurrentUserProvider
    {
        public CurrentUser _User { get; private set; }


        public void SetCurrentUser(CurrentUser currentUser)
        {
            _User = currentUser;
        }

    }
}
