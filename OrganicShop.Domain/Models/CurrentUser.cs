using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.Models
{
    public class CurrentUser
    {
        public long Id { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
    }
}
