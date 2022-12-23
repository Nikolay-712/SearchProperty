namespace SearchProperty.Data.Models.Addresses
{
    using System;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Town { get; set; }

        public string FullAddress { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string PropertyId { get; set; }
    }
}
