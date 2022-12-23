namespace SearchProperty.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using static SearchProperty.Common.GlobalConstants;

    public class AddressInputModel
    {
        [Display(Name = "Full Address")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(maximumLength: 250, ErrorMessage = LenghtErrorMessage, MinimumLength = 10)]
        public string FullAddress { get; init; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(maximumLength: 150, ErrorMessage = LenghtErrorMessage, MinimumLength = 10)]
        public string Street { get; init; }

        [Display(Name = "Town")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(maximumLength: 50, ErrorMessage = LenghtErrorMessage, MinimumLength = 5)]
        public string Town { get; init; }

        [Display(Name = "Neighborhood")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(maximumLength: 150, ErrorMessage = LenghtErrorMessage, MinimumLength = 10)]
        public string Neighborhood { get; init; }

        [Display(Name = "Coordinates")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        public double Lat { get; init; }

        [Display(Name = "Coordinates")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        public double Lng { get; init; }
    }
}
