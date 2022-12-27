namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Services.Mapping;

    public class ResidentalDetailsViewModel : IMapFrom<ResidentialDetails>
    {
        public ResidentialType ResidentialTypes { get; init; }

        public int Bedrooms { get; init; }

        public int Bathrooms { get; init; }

        public int YardSquareMeters { get; init; }

        public int Floor { get; init; }
    }
}
