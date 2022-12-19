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

        public string Location { get; set; }

        public string PropertyId { get; set; }
    }
}
