using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class BankCard : BaseEntity<long>
    {
        public string Cvv2 { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string OwnerName { get; set; }
        public long UserId { get; set; }



        public User User { get; set; }
    }
}
