namespace SearchProperty.Services.OfferedProperties
{
    using System.Threading.Tasks;

    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Web.ViewModels.OfferedProperties;

    public interface IPropertyService
    {
        Property AddProperty(PropertyInputModel propertyInput, string userId);

        TempPropertyViewModel ShowPropertyTempData(Property property);

        Task SavePropertyAsync(Property property, TempPropertyViewModel tempPropertyDetails);
    }
}
