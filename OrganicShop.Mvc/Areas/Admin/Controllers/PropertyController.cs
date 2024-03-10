using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using System.Security.Cryptography.Xml;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Mvc.Models.Toast;
using OrganicShop.Mvc.Extensions;
using System.Text.Json;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class PropertyController : BaseAdminController<PropertyController>
    {
        #region ctor

        private readonly IPropertyService _PropertyService;

        public PropertyController(IPropertyService PropertyService)
        {
            _PropertyService = PropertyService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterPropertyDto filter , SortPropertyDto sort, PagingDto paging)
        {
            filter.IsBase = true;
            var pageDto = await _PropertyService.GetAll(filter, sort, paging);
            return View(pageDto);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreatePropertyDto? createProperty)
        {
            if (createProperty != null)
            {
                var response = await _PropertyService.Create(createProperty);
                switch (response.Result)
                {
                    case EntityResult.Success:
                        return _ClientHandleResult.Toast(HttpContext,new Toast(ToastType.Success,response.Message));

                    case EntityResult.EntityExist:
                        return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));

                    default:
                        throw new Exception("no handled result.");
                }
            }
            return View();
        }




        //[HttpPost]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var response = await _PropertyService.Delete(Id);
        //    switch (response.Result)
        //    {
        //        case EntityResult.Success:
        //            return Partial("Index" , new Toast(ToastType.Success , response.Message , 5000));

        //        case EntityResult.NotFound:
        //            return Toast(new Toast(ToastType.Error, response.Message));
                
        //        default:
        //            throw new Exception("Unhandled Entity Result .");
        //    }
        //}

        [HttpDelete]
        //[HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _PropertyService.Delete(Id);
            switch (response.Result)
            {
                case EntityResult.Success:
                    var model = await _PropertyService.GetAll(new FilterPropertyDto() { IsBase = true });
                    return _ClientHandleResult.Partial(HttpContext,"Index",model,new Toast(ToastType.Success, response.Message));
                    return _ClientHandleResult.RedirectThenToast(HttpContext, TempData,"Index", new Toast(ToastType.Success, response.Message), true);

                case EntityResult.NotFound:
                    return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));

                default:
                    throw new Exception("Unhandled Entity Result .");
            }
        }
    }
}
