namespace SearchProperty.Services.OfferedProperties
{
    using System.Collections.Generic;
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
                PropertyType = propertyInput.PropertyType,
                Price = propertyInput.Price,
                Description = propertyInput.Description,
                SquareMeters = propertyInput.SquareMeters,
                UserId = userId,
                ForRent = propertyInput.ForRent,
            };

            var address = this.addressService.GenerateAddress(property.Id, propertyInput.Address);
            property.AddressId = address.Id;
            property.Address = address;

            return property;
        }

        public TempPropertyViewModel ShowPropertyTempData(Property property)
        {
            var tempProperty = new TempPropertyViewModel
            {
                PropertyType = property.PropertyType,
                CreatedOn = property.CreatedOn,
                Price = property.Price,
                Description = property.Description,
                SquareMeters = property.SquareMeters,
                ForRent = property.ForRent,
                Town = property.Address.Town,
                Location = property.Address.FullAddress,
            };

            return tempProperty;
        }

        public async Task SavePropertyAsync(Property property, TempPropertyViewModel tempPropertyDetails)
        {
            if (property.PropertyType == PropertyType.Residential)
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

            if (property.PropertyType == PropertyType.Business)
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
