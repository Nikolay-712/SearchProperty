namespace SearchProperty.Data.Models.Addresses
{
    using System;
    using System.Collections.Generic;

    public class RegionalTown
    {
        public RegionalTown()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Towns = new List<Town>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsRegionalTown { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
