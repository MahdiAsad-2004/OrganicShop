using OrganicShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Comment
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }

    }
}
