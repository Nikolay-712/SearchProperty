namespace SearchProperty.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SearchProperty.Data.Models.Addresses;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> town)
        {
            town
                .HasKey(x => x.Id);

            town
                .Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            town
                .Property(x => x.RegionalTownId)
                .IsRequired();
        }
    }
}
