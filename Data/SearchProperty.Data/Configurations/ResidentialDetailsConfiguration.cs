namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.OfferedProperties;

    public class ResidentialDetailsConfiguration : IEntityTypeConfiguration<ResidentialDetails>
    {
        public void Configure(EntityTypeBuilder<ResidentialDetails> details)
        {
            details
                .HasKey(x => x.Id);

            details
                .Property(x => x.ResidentialTypes)
                .IsRequired();

            details
                .Property(x => x.PropertyId)
                .IsRequired();

            details
                .Property(x => x.Bedrooms)
                .IsRequired();

            details
                .Property(x => x.Bathrooms)
                .IsRequired();
        }
    }
}
