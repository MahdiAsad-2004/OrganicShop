using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrganicShop.Mvc.ValidationsAttributes
{
    public class FileFormat : ValidationAttribute, IClientModelValidator
    {
        public string[] Formats { get; set; }
        public string FieldName { get; set; } = "فایل";
        string FormatsString { get; set; }

        public FileFormat(string[] formats)
        {
            if(formats.Any(a => string.IsNullOrWhiteSpace(a)) || !formats.Any())
            {
                throw new ArgumentException("formats is empty.");
            }
            Formats = formats.Select(a => a.Trim().ToLower()).ToArray();
            FormatsString = string.Join("/", Formats);
        }

        public override bool IsValid(object? value)
        {
            return true;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileFormat", $"فرمت {FieldName} {string.Join(" / ", Formats)} نیست");
            context.Attributes.Add("data-val-fileFormat-formats", $"{FormatsString}");
            context.Attributes.Add("data-val", "true");

        }

    }
}
