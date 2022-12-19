namespace SearchProperty.Data.Models.OfferedProperties
{
    using System;

    using SearchProperty.Data.Models.OfferedProperties.Enums;

    public class BusinessDetails
    {
        public BusinessDetails()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string PropertyId { get; set; }

        public BusinessType BusinessType { get; set; }
    }
}
