using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Controllers.Base;

namespace OrganicShop.Mvc.Areas.Admin
{
    [Area("Admin")]
    public class BaseAdminController<TController> : BaseController<TController> where TController : Controller
    {
       
    }



}
