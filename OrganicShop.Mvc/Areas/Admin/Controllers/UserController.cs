using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using System.Security.Cryptography.Xml;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IPermissionService _PermissionService;

        public UserController(IUserService UserService, IPermissionService permissionService)
        {
            _UserService = UserService;
            _PermissionService = permissionService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterUserDto filter, SortUserDto sort, PagingDto paging)
        {
            var pageDto = await _UserService.GetAll(filter, sort, paging);

            

            return View(pageDto);
            //return View(new PageDto<User,UserListDto,long>());
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Permissions"] = await _PermissionService.GetCombos();
            Response.Headers.Add("MyHeaderKey", "MyHeaderValue");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto? createUser)
        {
            if (createUser != null)
            {
                var response = await _UserService.Create(createUser);
                switch (response.Result)
                {
                    case EntityResult.Success:
                        break;

                    case EntityResult.EntityExist:
                        break;

                    case EntityResult.Failed:
                        break;

                    default:
                        throw new Exception("no handled result."); 
                }
            }
            else
            {
                ViewData["Permissions"] = await _PermissionService.GetCombos();
            }
            return View();
        }

     
        public async Task<bool> EmailExist(string email)
            => await _UserService.IsEmailExist(email);

        public async Task<bool> PhoneNumberExist(string phoneNumber)
            => await _UserService.IsPhoneNumberExist(phoneNumber);



        public async Task<IActionResult> Delete(long Id)
        {
            var response = await _UserService.Delete(Id);
            switch (response.Result)
            {
                case EntityResult.Success:
                    return Partial("Index" , new Toast(ToastType.Success , response.Message , 3000));

                case EntityResult.NotFound:
                    return Toast(new Toast(ToastType.Error, response.Message));
                
                default:
                    throw new Exception("Unhandled Entity Result .");
            }
        }
    }
}
