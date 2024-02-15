using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using System.Security.Cryptography.Xml;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        #region ctor

        private readonly IProductService _ProductService;
      
        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterProductDto filter, SortProductDto sort, PagingDto paging)
        {
            var pageDto = await _ProductService.GetAll(filter, sort, paging);
            return View(pageDto);

            //return View(new PageDto<Product,ProductListDto,long>());
        }






        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto? createProduct)
        {
            if (createProduct != null)
            {
                var result = await _ProductService.Create(createProduct);
                switch (result)
                {
                    //case EntityResult.success:
                    //    break;
                    //case EntityResult.NotFound:
                    //    break;
                    //case EntityResult.Failed:
                    //    break;
                    default:
                        break;
                }
            }
            return View();
        }



    }
}
