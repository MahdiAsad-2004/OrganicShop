using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using System.Security.Cryptography.Xml;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        #region ctor

        private readonly IUserService _UserService;
      
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterUserDto filter, SortUserDto sort, PagingDto paging)
        {
            var pageDto = await _UserService.GetAll(filter, sort, paging);
            return View(pageDto);

            //return View(new PageDto<User,UserListDto,long>());
        }




        //[HttpPost]
        //public async Task<IActionResult> Create(CreateUserDto? createUser)
        //{
        //    if (createUser != null) 
        //    {
        //        var result = await _UserService.Create(createUser);
        //        switch (result)
        //        {
        //            //case EntityResult.success:
        //            //    break;
        //            //case EntityResult.NotFound:
        //            //    break;
        //            //case EntityResult.Failed:
        //            //    break;
        //            default:
        //                break;
        //        }
        //    }
        //    return View();
        //}



    }
}
