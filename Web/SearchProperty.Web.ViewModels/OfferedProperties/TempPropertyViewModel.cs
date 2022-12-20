namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;

    public class TempPropertyViewModel
    {
        public string PropertyId { get; init; }

        public PropertyType PropertyType { get; init; }

        public decimal Price { get; init; }

        public string Description { get; init; }

        public int SquareMeters { get; init; }

        public bool ForRent { get; init; }

        public string Town { get; init; }

        public string Location { get; init; }
    }
}
