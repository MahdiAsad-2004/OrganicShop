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
        public readonly CurrentUser _User;


        //public void SetCurrentUser(CurrentUser currentUser)
        //{
        //    _User = currentUser;

        //}

        public CurrentUserProvider(CurrentUser currentUser)
        {
            _User = currentUser;
        }

    }
}
