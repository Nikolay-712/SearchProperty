namespace SearchProperty.Services.Addresses
{
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Web.ViewModels.Addresses;

    public interface IAddressService
    {
        Address GenerateAddress(string propertyId, AddressInputModel addressInput);
    }
}
