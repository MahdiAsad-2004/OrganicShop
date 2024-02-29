using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        #region ctor

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            var property = new Property()
            {
                Id = 1,
                Title = "Title",
                Value = "Test",
                Priority = 1,
            };

            return Json(_mapper.Map<PropertyListDto>(property));

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
