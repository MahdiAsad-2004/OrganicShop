using Microsoft.AspNetCore.Mvc;
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



        //#region Toast

        //protected IActionResult Toast(Toast message)
        //{
        //    Response.Headers.Add("ResponseDataType", "toast");
        //    return Content(JsonSerializer.Serialize(message));
        //}

        //#endregion



        //#region partial
        //protected IActionResult Partial(string name, object? model, Toast message)
        //{
        //    Response.Headers.Add("ResponseDataType", "partial");
        //    message.SetToastOnResponse(Response);
        //    return PartialView(name, model);
        //}
        //protected IActionResult Partial(string name, object? model, Toast message, string targetElementId)
        //{
        //    Response.Headers.Add("ResponseDataType", "partial");
        //    Response.Headers.Add("targetElementId", targetElementId);
        //    message.SetToastOnResponse(Response);
        //    return PartialView(name, model);
        //}

        //#endregion



        //#region toast => redirect

        //protected IActionResult ToastThenRedirect(string actionName, Toast message, bool replace)
        //{
        //    message.SetToastOnResponse(Response);
        //    Response.Headers.Add("ResponseDataType", "toast-redirect");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}
        //protected IActionResult ToastThenRedirect(string actionName, string controllerName, Toast message, bool replace)
        //{
        //    message.SetToastOnResponse(Response);
        //    Response.Headers.Add("ResponseDataType", "toast-redirect");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName, controllerName)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}
        //protected IActionResult ToastThenRedirect(string actionName, string controllerName, object routeValues, Toast message, bool replace)
        //{
        //    message.SetToastOnResponse(Response);
        //    Response.Headers.Add("ResponseDataType", "toast-redirect");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName, controllerName, routeValues)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}

        //#endregion



        //#region redirect => toast

        //protected IActionResult RedirectThenToast(string actionName, Toast message, bool replace)
        //{
        //    ToastOnTempData(message);
        //    Response.Headers.Add("ResponseDataType", "redirect-toast");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}
        //protected IActionResult RedirectThenToast(string actionName, string controller, Toast message, bool replace)
        //{
        //    ToastOnTempData(message);
        //    Response.Headers.Add("ResponseDataType", "redirect-toast");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName, controller)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}
        //protected IActionResult RedirectThenToast(string actionName, string controller, object routeValues, Toast message, bool replace)
        //{
        //    ToastOnTempData(message);
        //    Response.Headers.Add("ResponseDataType", "redirect-toast");
        //    Redirect redirect = new Redirect()
        //    {
        //        Url = $"{GetActionAreaName()}{Url.Action(actionName, controller, routeValues)}",
        //        IsReplace = replace,
        //        TimeOut = 0,
        //    };
        //    return Content(redirect.GetJsonStrng());
        //}

        //#endregion



        //#region toast => refresh

        //protected IActionResult ToastThenRfresh(Toast message)
        //{
        //    Response.Headers.Add("ResponseDataType", "toast-refresh");
        //    message.SetToastOnResponse(Response);
        //    return Content("");
        //}

        //#endregion



    }



}

