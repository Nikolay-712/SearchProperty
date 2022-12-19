namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.OfferedProperties;

    public class BusinessDetailsConfiguration : IEntityTypeConfiguration<BusinessDetails>
    {
       public void Configure(EntityTypeBuilder<BusinessDetails> details)
        {
            details
                .HasKey(x => x.Id);

            details
                .Property(x => x.BusinessType)
                .IsRequired();

            details
                .Property(x => x.PropertyId)
                .IsRequired();
        }
    }
}
