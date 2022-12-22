namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SearchProperty.Data.Models.OfferedProperties.Enums;

    using static SearchProperty.Common.GlobalConstants;

    public class TempPropertyViewModel : ResidentialDetailsInputModel
    {
        public string PropertyId { get; init; }

        public DateTime CreatedOn { get; set; }

        public PropertyType PropertyType { get; init; }

        public decimal Price { get; init; }

        public string Description { get; init; }

        public int SquareMeters { get; init; }

        public bool ForRent { get; init; }

        public string Town { get; init; }

        public string Location { get; init; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [EnumDataType(typeof(BusinessType), ErrorMessage = InvalidPropertyType)]
        public BusinessType BusinessType { get; init; }
    }
}
