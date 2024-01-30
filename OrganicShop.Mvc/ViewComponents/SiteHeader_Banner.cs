using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteHeader_Banner : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteHeader_Banner");
        }
    }


   
}
