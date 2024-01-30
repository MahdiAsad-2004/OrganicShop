namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public record CreatePermissionDto
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public byte? ParentId { get; set; }
    }


}
