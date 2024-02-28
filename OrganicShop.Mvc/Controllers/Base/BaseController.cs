using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Mvc.Models.Toast;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrganicShop.Mvc.Controllers.Base
{
    public class BaseController : Controller
    {
        #region ctor

        public BaseController()
        {
        }

        #endregion



        protected IActionResult Toast(Toast message)
        {
            Response.Headers.Add("ResponseDataType", "toast");
            return Content(JsonSerializer.Serialize(message));
        }



        protected IActionResult Partial(string name, Toast message)
        {
            Response.Headers.Add("ResponseDataType", "partial");
            message.SetMessageOnResponse(Response);
            return PartialView(name);
        }
        protected IActionResult Partial(string name, Toast message , string targetElementId)
        {
            Response.Headers.Add("ResponseDataType", "partial");
            Response.Headers.Add("targetElementId", targetElementId);
            message.SetMessageOnResponse(Response);
            return PartialView(name);
        }

        protected IActionResult Partial(string partialName, Toast message, RedirectToActionResult afterMessageRedirect)
        {
            Response.Headers.Add("ResponseDataType", "partial");
            Response.Headers.Add("RedirectUrl", Url.ActionLink(afterMessageRedirect.ActionName, afterMessageRedirect.ControllerName, afterMessageRedirect.RouteValues));
            message.SetMessageOnResponse(Response);
            return PartialView(partialName);
        }

        protected IActionResult Partial(string partialName, Toast message, RedirectToActionResult afterMessageReplace, bool replace)
        {
            Response.Headers.Add("ResponseDataType", "partial");
            Response.Headers.Add("ReplaceUrl", Url.ActionLink(afterMessageReplace.ActionName, afterMessageReplace.ControllerName, afterMessageReplace.RouteValues));
            message.SetMessageOnResponse(Response);
            return PartialView(partialName);
        }

        protected IActionResult Partial(string partialName, Toast message, bool refresh)
        {
            Response.Headers.Add("ResponseDataType", "partial");
            Response.Headers.Add("Refresh", refresh.ToString());
            message.SetMessageOnResponse(Response);
            return PartialView(partialName);
        }


        protected IActionResult Redirect(string actionName, Toast message)
        {
            Response.Headers.Add("ResponseDataType", "redirect");
            message.SetMessageOnResponse(Response);
            return Content(Url.Action(actionName));
        }

        protected IActionResult Redirect(string actionName, string controller, Toast message)
        {
            Response.Headers.Add("ResponseDataType", "redirect");
            message.SetMessageOnResponse(Response);
            return Content(Url.Action(actionName, controller));
        }
        protected IActionResult Redirect(string actionName, string controller, object routeValues, Toast message)
        {
            Response.Headers.Add("ResponseDataType", "redirect");
            message.SetMessageOnResponse(Response);
            return Content(Url.Action(actionName, controller, routeValues));
        }



    }

}

