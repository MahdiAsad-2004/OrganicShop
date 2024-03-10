using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System.Data.SqlTypes;
using System.Linq.Expressions;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class SortUserDto : BaseSortDto<Entities.User, long>
    {
        public SortOrder? Name { get; set; } = null;


    }



}
