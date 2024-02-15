using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Models;
using OrganicShop.Mvc;
using OrganicShop.Mvc.Areas.Admin;
using System.Diagnostics;
using System.Security.Claims;

namespace OrganicShop.Mvc.Extensions
{
    public static class HttpExnesions
    {
        public static CurrentUser GetCurrentUser(this HttpContext httpContext)
        {
            CurrentUser currentUser = new CurrentUser();
            if (httpContext.User != null)
            {
                if (httpContext.User.Identity != null)
                {
                    //currentUser.Id = long.Parse(httpContext.User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                    //currentUser.Username = httpContext.User.Identity.Name;
                    //currentUser.Role = Enum.Parse<Role>(httpContext.User.Claims.First(a => a.Type == ClaimTypes.Role).Value);
                    //Console.WriteLine($".......{currentUser.Username}...........");
                }

            }
            return currentUser;
        }
    }
}
