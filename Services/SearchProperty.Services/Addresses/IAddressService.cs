namespace SearchProperty.Services.Addresses
{
    using SearchProperty.Data.Models.Addresses;

    public interface IAddressService
    {
        Address GenerateAddress(string propertyId);
    }
}
