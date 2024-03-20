﻿using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Mvc.Controllers.Base.Result;
using OrganicShop.Mvc.Models.Redirect;
using OrganicShop.Mvc.Models.Toast;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace OrganicShop.Mvc.Controllers.Base
{
    public class BaseController<TController> : Controller where TController : Controller
    {
        #region ctor

        protected readonly ClientHandleResult<TController> _ClientHandleResult = new ClientHandleResult<TController>(); 

        public BaseController()
        {

        }
        

        #endregion


        private string? GetActionAreaName()
        {
            var areaAttribute = ControllerContext.ActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>();
            if (areaAttribute != null)
            {
                return $"/{areaAttribute.RouteValue}";
            }
            return null;
        }
        protected void ToastOnTempData(Toast toast)
        {
            TempData["Toast"] = toast.Serialize();
        }



        public IActionResult Refresh() 
        {
            var route = $"{GetActionAreaName()}/{ControllerContext.ActionDescriptor.ControllerName}/{ControllerContext.ActionDescriptor.ActionName}";
            return Redirect(route);   
        }

        public IActionResult NotFoundPage()
        {
            return Redirect("/Error/404");
        }


    }



}

