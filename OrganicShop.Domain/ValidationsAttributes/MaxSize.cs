using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Mvc.ValidationsAttributes
{
    public class MaxSize : ValidationAttribute, IClientModelValidator
    {
        public int Size { get; set; }
        public string FieldName { get; set; } = "فایل";

        public MaxSize(int sizeKB)
        {
            Size = sizeKB;

        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-maxSize", $"حداکثر سایز {FieldName} KB {Size} است");
            context.Attributes.Add("data-val-maxSize-max", $"{Size}");

        }

    }
}
