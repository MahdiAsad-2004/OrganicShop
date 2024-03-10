using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController<HomeController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
