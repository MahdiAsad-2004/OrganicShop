using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Providers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Models;
using OrganicShop.Mvc;
using OrganicShop.Mvc.Areas.Admin;
using System.Diagnostics;
using System.Security.Claims;
using OrganicShop.Mvc.Extensions;
using DryIoc;


namespace OrganicShop.Mvc.Middlewares
{
    public class CurrentUserProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebApplication _application;

        public CurrentUserProviderMiddleware(RequestDelegate next, WebApplication application)
        {
            _next = next;
            _application = application;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            var currentUserProvider = _application.Services.GetService<CurrentUserProvider>();
            var currentUser = httpContext.GetCurrentUser();
            currentUserProvider.SetCurrentUser(currentUser);
            await _next(httpContext);
        }

    }
}
