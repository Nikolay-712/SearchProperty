namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SearchProperty.Data.Models.OfferedProperties.Enums;

    using static SearchProperty.Common.GlobalConstants;

    public class PropertyInputModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [EnumDataType(typeof(PropertyType), ErrorMessage = InvalidPropertyType)]
        public PropertyType PropertyType { get; init; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(minimum: 10, maximum: double.MaxValue, ErrorMessage = RangeErrorMessage)]
        public decimal Price { get; init; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(maximumLength: 700, ErrorMessage = LenghtErrorMessage, MinimumLength = 10)]
        public string Description { get; init; }

        [Display(Name = "Square Meters")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(minimum: 10, maximum: 2000, ErrorMessage = RangeErrorMessage)]
        public int SquareMeters { get; init; }

        public bool ForRent { get; init; }

        public string PropertyId { get; set; }
    }
}
