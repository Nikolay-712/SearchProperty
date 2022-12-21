namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Data.Models.OfferedProperties;

    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> property)
        {
            property
                .HasKey(x => x.Id);

            property
                .Property(x => x.PropertyType)
                .IsRequired();

            property.Property(x => x.Price)
                .IsRequired()
                .HasColumnType<decimal>("decimal")
                .HasPrecision(10, 2);

            property
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(700)
                .IsUnicode();

            property
                .Property(x => x.SquareMeters)
                .IsRequired();

            property
                .Property(x => x.AddressId)
                .IsRequired();

            property
                .Property(x => x.UserId)
                .IsRequired();

            property
                .HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Address>(x => x.PropertyId);

            property
                .HasOne(x => x.ResidentalDetails)
                .WithOne()
                .HasForeignKey<ResidentialDetails>(x => x.PropertyId);

            property
                .HasOne(x => x.BusinessDetails)
                .WithOne()
                .HasForeignKey<BusinessDetails>(x => x.PropertyId);
        }
    }
}
