namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.Addresses;

    internal class RegionalTownConfiguration : IEntityTypeConfiguration<RegionalTown>
    {
        public void Configure(EntityTypeBuilder<RegionalTown> town)
        {
            town
                .HasKey(x => x.Id);

            town
                .Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            town
                .HasMany(x => x.Towns)
                .WithOne()
                .HasForeignKey(x => x.RegionalTownId);
        }
    }
}
