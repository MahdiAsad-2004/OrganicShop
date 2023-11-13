using OrganicShop.Domain.Enum;
using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class User : BaseEntity<long>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }


        public Image? ProfileImage { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<BankCard>? BankCards { get; set; }
        public ICollection<Discount>? Discounts { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
