using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class UpdateCommentDto : BaseDto<long>
    {
        public CommentStatus Status { get; set; }
        public long UserId { get; set; }

    }

}
