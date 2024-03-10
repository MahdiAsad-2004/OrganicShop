﻿using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

    
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> TestAction()
        {
            await Console.Out.WriteLineAsync();

            
            //return RedirectToAction("Index", new { name = "asd", pass = "zxcv", flag = false });

            var t = new Toast(ToastType.Error, "asdadasd 654654a6d4d6a54d ", 5000);

            return _ClientHandleResult.RedirectThenToast(HttpContext,TempData,"Index",t,false);

            //return _ClientHandleResult.Partial(HttpContext, "Privacy", null, t);

            //return _ClientHandleResult.ToastThenRedirect(HttpContext, "Index", "Home", new {name = "asd",pass="zxcv",flag=false }, t, false);

            return _ClientHandleResult.Toast(HttpContext,t);

        }



        [HttpPut]
        public async Task<IActionResult> TestAction(string name)
        {
            return Content($"Name: {name}");
        }


        [HttpPost]
        public async Task<IActionResult> TestAction(string name , int number)
        {
            return Content($"Name: {name} ---- Number: {number}");
        }

    }
}
