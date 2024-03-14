using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController<CategoryController>
    {
        #region ctor

        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        #endregion


        public async Task<IActionResult>  Index()
        {
            var page = await _CategoryService.GetAll();
            return View(page);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await _CategoryService.GetCombos();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto? create)
        {
            if(create != null)
            {
                await Console.Out.WriteLineAsync(create.Title);
                var response = await _CategoryService.Create(create);

                if (response.Result == ResponseResult.Success)
                {
                    ToastOnTempData(new Toast(ToastType.Success, response.Message));
                    return Refresh();
                }

                ToastOnTempData(new Toast(ToastType.Error, response.Message));
                return Refresh();
            }
            else
            {
                ViewData["Categories"] = await _CategoryService.GetCombos();
            }
            return View();
        }





        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            //var response = await _CategoryService.Delete(Id);
            if (true)
            {
                var model = await _CategoryService.GetAll();
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("Index",model), new Toast(ToastType.Success, "Success"));
            }
            //return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }






    }
}
