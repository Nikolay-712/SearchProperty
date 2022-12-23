namespace SearchProperty.Services.Addresses
{
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Web.ViewModels.Addresses;

    public class AddressService : IAddressService
    {
        public Address GenerateAddress(string propertyId, AddressInputModel addressInput)
        {
            var address = new Address
            {
                FullAddress = addressInput.FullAddress,
                Street = addressInput.Street,
                Town = addressInput.Town,
                Neighborhood = addressInput.Neighborhood,
                Lat = addressInput.Lat,
                Lng = addressInput.Lng,
                PropertyId = propertyId,
            };

            return address;
        }
    }
}
