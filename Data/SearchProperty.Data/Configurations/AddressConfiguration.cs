namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.Addresses;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address
                .HasKey(x => x.Id);

            address
                .Property(x => x.Town)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            address
                .Property(x => x.FullAddress)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            address
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode();

            address
                .Property(x => x.Neighborhood)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode();

            address
                .Property(x => x.Lat)
                .IsRequired()
                .HasColumnType<double>("decimal")
                .HasPrecision(10, 4);

            address
                .Property(x => x.Lng)
                .IsRequired()
                .HasColumnType<double>("decimal")
                .HasPrecision(10, 4);

            address
                .Property(x => x.PropertyId)
                .IsRequired();
        }
    }
}
