﻿using Microsoft.AspNetCore.Mvc;
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
using DryIoc.Microsoft.DependencyInjection;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Ioc;
using OrganicShop.Domain.IProviders;


namespace OrganicShop.Mvc.Middlewares
{
    public class ApplicationUserProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebApplication _application;

        public ApplicationUserProviderMiddleware(RequestDelegate next, WebApplication application)
        {
            _next = next;
            _application = application;
        }


        public async Task Invoke(HttpContext httpContext)
        {


            //var applicationUserProvider = DryIocAdapter.GetServiceProvider(InversionOfControl.GetContainer()).GetService<IApplicationUserProvider>();
            //var applicationUserProvider = DryIocAdapter.BuildServiceProvider(InversionOfControl.GetContainer()).GetService<IApplicationUserProvider>();
            //var applicationUserProvider = Resolver.Resolve<IApplicationUserProvider>(InversionOfControl.GetContainer());




            var applicationUserProvider = _application.Services.GetService<IApplicationUserProvider>();
            var applicationUser = httpContext.GetCurrentUser();
            //applicationUser = new ApplicationUser()
            //{
            //    Id = 10,
            //    UserName = "user nameee",
            //    Role = Role.Admin,
            //};
            applicationUserProvider.SetCurrentUser(applicationUser);

            //await Console.Out.WriteLineAsync($"///////////  {applicationUserProvider.User.Id}  /////////////");

            //httpContext.Response.StatusCode = 404;
            //await httpContext.Response.StartAsync();


            //httpContext.Response.Redirect("/Admin/Home/Index");


            //httpContext.Response.StatusCode = 301;
            //httpContext.Response.Headers.Location = "https://localhost:7196/Admin/Home/";
            //await httpContext.Response.StartAsync();




            await _next(httpContext);
        }

    }







}
