namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using System.ComponentModel.DataAnnotations;

    using SearchProperty.Data.Models.OfferedProperties.Enums;

    using static SearchProperty.Common.GlobalConstants;

    public class ResidentialDetailsInputModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [EnumDataType(typeof(ResidentialType), ErrorMessage = InvalidPropertyType)]
        public ResidentialType ResidentialTypes { get; init; }

        [Display(Name = "Bedrooms")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(minimum: 1, maximum: 10, ErrorMessage = RangeErrorMessage)]
        public int Bedrooms { get; init; }

        [Display(Name = "Bathrooms")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(minimum: 1, maximum: 10, ErrorMessage = RangeErrorMessage)]
        public int Bathrooms { get; init; }

        [Display(Name = "Yard Square Meters")]
        [Range(minimum: 10, maximum: 3000, ErrorMessage = RangeErrorMessage)]
        public int? YardSquareMeters { get; init; }

        [Display(Name = "Floor")]
        [Range(minimum: 0, maximum: 150, ErrorMessage = RangeErrorMessage)]
        public int? Floor { get; init; }
    }
}
