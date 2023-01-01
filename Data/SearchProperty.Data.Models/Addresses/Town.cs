namespace SearchProperty.Data.Models.Addresses
{
    using System;

    public class Town
    {
        public Town()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string RegionalTownId { get; set; }
    }
}
