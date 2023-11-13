using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class ContactUs : BaseEntity<byte>
    {
        public string Email1 { get; set; }
        public string? Email2 { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public string Office1 { get; set; }
        public string? Office2 { get; set; }
        public string? Office3 { get; set; }
    }
}
