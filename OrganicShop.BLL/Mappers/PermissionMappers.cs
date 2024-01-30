using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.PermissionDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class PermissionMappers
    {
        public static PermissionListDto ToListDto(this Permission Permission)
        {
            return new PermissionListDto
            {
                Id = Permission.Id,
                Title = Permission.Title,
                EnTitle = Permission.EnTitle,
                ParentTitle = Permission.Parent == null ? null : $"{Permission.Parent.Title}({Permission.Parent.EnTitle})",
            };
        }

        public static Permission ToModel(this CreatePermissionDto create)
        {
            return new Permission()
            {
                Title = create.Title,
                EnTitle = create.EnTitle,
            };
        }

        public static Permission ToModel(this UpdatePermissionDto update, Permission Permission)
        {
            Permission.Title = update.Title;
            Permission.EnTitle = update.EnTitle;
            Permission.ParentId = update.ParentId;
            return Permission;
        }









    }
}
