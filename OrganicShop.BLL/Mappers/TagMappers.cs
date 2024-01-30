using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.TagDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class TagMappers
    {
        public static TagListDto ToListDto(this Tag Tag)
        {
            return new TagListDto
            {
                Id = Tag.Id,
                Title = Tag.Title,
            };
        }

        public static Tag ToModel(this CreateTagDto create)
        {
            return new Tag()
            {
                Title = create.Title.ToText(),
            };
        }

        public static Tag ToModel(this UpdateTagDto update, Tag Tag)
        {
            Tag.Title = update.Title.ToText();
            return Tag;
        }









    }
}
