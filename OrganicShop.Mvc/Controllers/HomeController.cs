using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        #region ctor

        public HomeController()
        {
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            //TempData["TestData"] = "Hello";
            return View();
        }

        public async Task<IActionResult> TestAction()
        {
            //return Redirect("Privacy" , new Toast(ToastType.Error, "Bad Request .", 5000));
            return Partial("Privacy",new Toast(ToastType.Error , "Bad Request ." , 5000),RedirectToAction("index" , new { Pass = 45465456456}));
            
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
