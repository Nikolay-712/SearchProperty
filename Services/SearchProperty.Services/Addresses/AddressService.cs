namespace SearchProperty.Services.Addresses
{
    using SearchProperty.Data.Models.Addresses;

    public class AddressService : IAddressService
    {
        public Address GenerateAddress(string propertyId)
        {
            var address = new Address
            {
                Town = "Sofiq",
                Location = "test location for new property",
                PropertyId = propertyId,
            };

            return address;
        }
    }
}
