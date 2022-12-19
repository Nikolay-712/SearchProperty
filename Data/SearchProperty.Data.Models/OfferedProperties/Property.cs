namespace SearchProperty.Data.Models.OfferedProperties
{
    using System;

    using SearchProperty.Data.Models.Addresses;

    public class Property
    {
        public Property()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int SquareMeters { get; set; }

        public string AddressId { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }

        public bool ForRent { get; set; }

        public string ResidentalDetailsId { get; set; }

        public ResidentialDetails ResidentalDetails { get; set; }

        public string BusinessDetailsId { get; set; }

        public BusinessDetails BusinessDetails { get; set; }
    }
}
