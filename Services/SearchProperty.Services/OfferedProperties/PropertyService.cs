namespace SearchProperty.Services.OfferedProperties
{
    using SearchProperty.Data;
    using SearchProperty.Data.Models.OfferedProperties;
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

        public ResidentialDetailsInputModel ShowPropertyTempData(Property property)
        {
            var tempProperty = new ResidentialDetailsInputModel
            {
                Price = property.Price,
                Description = property.Description,
                SquareMeters = property.SquareMeters,
                ForRent = property.ForRent,
                Town = property.Address.Town,
                Location = property.Address.Location,
            };

            return tempProperty;
        }
    }
}
