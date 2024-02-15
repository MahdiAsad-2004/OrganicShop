using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Mvc.Areas.Admin
{
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
       



    }



    public class StateService
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; } = string.Empty;


        public StateService(HttpContext context)
        {
            Username = context.User.Identity.Name;
        }
    }

}
