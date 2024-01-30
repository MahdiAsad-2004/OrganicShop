using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.ContactUsDtos
{
    public class UpdateContactUsDto
    {
        public string Address { get; set; }
        public string Description { get; set; }
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
