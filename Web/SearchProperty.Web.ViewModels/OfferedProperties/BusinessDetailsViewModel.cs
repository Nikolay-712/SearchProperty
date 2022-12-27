namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Services.Mapping;

    public class BusinessDetailsViewModel : IMapFrom<BusinessDetails>
    {
        public BusinessType BusinessType { get; init; }

    }
}
