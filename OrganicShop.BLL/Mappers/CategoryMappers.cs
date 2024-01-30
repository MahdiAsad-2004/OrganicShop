using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CategoryDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryListDto ToListDto(this Category Category)
        {
            return new CategoryListDto
            {
                Id = Category.Id,
                Title = Category.Title,
                EnTitle = Category.EnTitle,
                Type = Category.Type.ToStringValue(),
                ParentTitle = Category.Parent!.Title,
                ParentEnTitle = Category.Parent!.EnTitle,
            };
        }

        public static Category ToModel(this CreateCategoryDto create)
        {
            return new Category()
            {
                Title = create.Title.ToText(),
                EnTitle = create.EnTitle.ToText(),
                Type = create.Type,
                ParentId = create.ParentId > 0 ? create.ParentId : null,
            };
        }

        public static Category ToModel(this UpdateCategoryDto update, Category Category)
        {
            Category.Title = update.Title.ToText();
            Category.EnTitle = update.EnTitle.ToText();
            Category.Type = update.Type;
            Category.ParentId = update.ParentId > 0 ? update.ParentId : null;
            return Category;
        }









    }
}
