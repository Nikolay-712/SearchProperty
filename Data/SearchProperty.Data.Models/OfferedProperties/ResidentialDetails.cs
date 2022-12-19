namespace SearchProperty.Data.Models.OfferedProperties
{
    using System;

    using SearchProperty.Data.Models.OfferedProperties.Enums;

    public class ResidentialDetails
    {
        public ResidentialDetails()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string PropertyId { get; set; }

        public ResidentialType ResidentialTypes { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int? YardSquareMeters { get; set; }

        public int? Floor { get; set; }
    }
}
