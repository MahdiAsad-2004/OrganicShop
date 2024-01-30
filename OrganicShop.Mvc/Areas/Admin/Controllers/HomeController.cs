using Microsoft.AspNetCore.Mvc;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
