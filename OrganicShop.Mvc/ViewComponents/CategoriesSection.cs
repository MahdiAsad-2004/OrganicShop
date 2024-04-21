using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{

    public class CategoriesSection : ViewComponent
    {
        #region ctor
        
        private readonly ICategoryService _CategoryService;
        public CategoriesSection(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryListDto> categoryListDtos;
            int? parentCategoryId = ViewComponentContext.Arguments["ParentCategoryId"] as int?;
            if(parentCategoryId != null)
            {
                categoryListDtos = (await _CategoryService.GetAll(new FilterCategoryDto { ParentId = parentCategoryId })).Data.List;
            }
            else
            {
                categoryListDtos = (await _CategoryService.GetAll(new FilterCategoryDto {ParentId = 0 })).Data.List;
            }
            return View("CategoriesSection",categoryListDtos);
        }
    }


   
}
