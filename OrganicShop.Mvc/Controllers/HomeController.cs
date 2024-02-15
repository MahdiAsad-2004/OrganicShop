using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Mvc;
using System.Diagnostics;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : Controller
    {
        #region ctor

        public HomeController()
        {
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return Content("Error");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    }
}
