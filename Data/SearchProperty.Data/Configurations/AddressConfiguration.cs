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
                .Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode();

            address
                .Property(x => x.PropertyId)
                .IsRequired();
        }
    }
}
