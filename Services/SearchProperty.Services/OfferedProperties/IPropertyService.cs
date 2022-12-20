namespace SearchProperty.Services.OfferedProperties
{
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Web.ViewModels.OfferedProperties;

    public interface IPropertyService
    {
        Property AddProperty(PropertyInputModel propertyInput, string userId);

        ResidentialDetailsInputModel ShowPropertyTempData(Property property);
    }
}
