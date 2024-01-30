using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.PropertyDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class PropertyMappers
    {
        public static PropertyListDto ToListDto(this Property Property)
        {
            return new PropertyListDto
            {
                Id = Property.Id,
                Title = Property.Title,
                Value = Property.Value,
            };
        }

        public static Property ToModel(this CreatePropertyDto create)
        {
            return new Property()
            {
                Title = create.Title,
                Value = create.Value,
                IsBase = create.IsBase,
                Priority = create.Priority,
                ProductId = create.ProductId,
            };
        }

        public static Property ToModel(this UpdatePropertyDto update, Property Property)
        {
            Property.Title = update.Title;
            Property.Value = update.Value;
            Property.IsBase = update.IsBase;
            Property.Priority = update.Priority;
            Property.ProductId = update.ProductId;
            return Property;
        }









    }
}
