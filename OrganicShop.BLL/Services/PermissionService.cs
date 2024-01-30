using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class PermissionService : IPermissionService
    {
        #region ctor

        private readonly IPermissionRepository _PermissionRepository;
        private readonly IPermissionUsersRepository _PermissionUsersRepository;

        public PermissionService(IPermissionRepository permissionRepository , IPermissionUsersRepository permissionUsersRepository)
        {
            _PermissionRepository = permissionRepository;
            _PermissionUsersRepository = permissionUsersRepository;
        }

        #endregion



        public async Task<PageDto<Permission, PermissionListDto, byte>> GetAll(FilterPermissionDto filter, SortPermissionDto sort, PagingDto paging)
        {
            var query = _PermissionRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ParentId != null)
                query = query.Where(q => q.ParentId == filter.ParentId);


            if (filter.UserId != null)
            {
                IQueryable<User> query1 = _PermissionUsersRepository.GetQueryable().Where(q => q.UserId == filter.UserId).Select(a => a.User).AsQueryable();
                query = query.IntersectBy(query1.Select(a => a.Id) , b => b.Id);

            }

            #endregion

            #region sort

            sort.ApplyBaseSort(query);

            if (sort.Title == true) query = query.OrderBy(o => o.Title);
            if (sort.Title == false) query = query.OrderByDescending(o => o.Title);

            if (sort.EnTitle == true) query = query.OrderBy(o => o.EnTitle);
            if (sort.EnTitle == false) query = query.OrderByDescending(o => o.EnTitle);

            #endregion

            PageDto<Permission, PermissionListDto, byte> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();

            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreatePermissionDto create)
        {
            Permission Permission = create.ToModel();

            #region relations

            if (create.ParentId != null)
            {
                if (_PermissionRepository.GetQueryable().Any(a => a.Id == create.ParentId) == false)
                    return EntityResultCreate.Failed;
                Permission.ParentId = create.ParentId;
            }

            #endregion

            await _PermissionRepository.Add(Permission,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdatePermissionDto update)
        {
            Permission? Permission = await _PermissionRepository.GetAsTracking(update.Id);

            if (Permission == null)
                return EntityResultUpdate.NotFound;

            #region relation

            if (update.ParentId != null)
            {
                if (_PermissionRepository.GetQueryable().Any(a => a.Id == update.ParentId) == false)
                    return EntityResultUpdate.Failed;
            }

            #endregion

            await _PermissionRepository.Update(update.ToModel(Permission), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(byte delete)
        {

            Permission? Permission = await _PermissionRepository.GetAsTracking(delete);

            if (Permission == null)
                return EntityResultDelete.NotFound;

            await _PermissionRepository.SoftDelete(Permission, 1);
            return EntityResultDelete.success;
        }
    }
}
