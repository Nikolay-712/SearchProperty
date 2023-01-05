namespace SearchProperty.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Web.ViewModels.Addresses;

    using static SearchProperty.Common.GlobalConstants;

    public class SearchInputModel
    {
        public IEnumerable<TownViewModel> AllTowns { get; init; }

        [Display(Name = "Town")]
        [Required(ErrorMessage = RequiredFieldMessage)]
        public string Town { get; init; }

        public bool ForRent { get; init; }

        [EnumDataType(typeof(PropertyType), ErrorMessage = InvalidPropertyType)]
        public PropertyType Type { get; init; }

        public IEnumerable<string> PropertyType { get; init; }

        public IEnumerable<string> Neighborhoods { get; init; }

        public List<string> BedroomsCount { get; init; }
    }
}
