namespace SearchProperty.Services.OfferedProperties
{
    using System.Threading.Tasks;

    using SearchProperty.Data;
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Services.Addresses;
    using SearchProperty.Web.ViewModels.OfferedProperties;

    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IAddressService addressService;

        public PropertyService(ApplicationDbContext applicationDbContext, IAddressService addressService)
        {
            this.applicationDbContext = applicationDbContext;
            this.addressService = addressService;
        }

        public Property AddProperty(PropertyInputModel propertyInput, string userId)
        {
            var property = new Property
            {
                Price = propertyInput.Price,
                Description = propertyInput.Description,
                SquareMeters = propertyInput.SquareMeters,
                UserId = userId,
                ForRent = propertyInput.ForRent,
            };

            var address = this.addressService.GenerateAddress(property.Id);
            property.AddressId = address.Id;
            property.Address = address;

            return property;
        }

        public TempPropertyViewModel ShowPropertyTempData(Property property)
        {
            var tempProperty = new TempPropertyViewModel
            {
                PropertyType = property.PropertyType,
                Price = property.Price,
                Description = property.Description,
                SquareMeters = property.SquareMeters,
                ForRent = property.ForRent,
                Town = property.Address.Town,
                Location = property.Address.Location,
            };

            return tempProperty;
        }

        public async Task SavePropertyAsync(Property property, TempPropertyViewModel tempPropertyDetails)
        {
            if (tempPropertyDetails.PropertyType == PropertyType.Residential)
            {
                var details = new ResidentialDetails
                {
                    PropertyId = property.Id,
                    ResidentialTypes = tempPropertyDetails.ResidentialTypes,
                    Bathrooms = tempPropertyDetails.Bathrooms,
                    Bedrooms = tempPropertyDetails.Bedrooms,
                    YardSquareMeters = tempPropertyDetails.YardSquareMeters,
                    Floor = tempPropertyDetails.Floor,
                };

                property.ResidentalDetails = details;
                property.ResidentalDetailsId = details.Id;
            }

            if (tempPropertyDetails.PropertyType == PropertyType.Business)
            {
                var details = new BusinessDetails
                {
                    PropertyId = property.Id,
                    BusinessType = tempPropertyDetails.BusinessType,
                };

                property.BusinessDetails = details;
                property.BusinessDetailsId = details.Id;
            }

            await this.applicationDbContext.Properties.AddAsync(property);
            await this.applicationDbContext.SaveChangesAsync();
        }
    }
}
