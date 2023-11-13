using OrganicShop.Domain.Enum;
using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Comment: BaseEntity<long>
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public long UserId { get; set; }
        
        
        public User User { get; set; }



    }
}
