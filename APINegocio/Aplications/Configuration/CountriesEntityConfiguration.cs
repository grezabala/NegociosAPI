using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class CountriesEntityConfiguration : BasesEntityConfiguration<Countries>
    {
        public CountriesEntityConfiguration()
        {
            TableName = "Countries";
        }
        public override void Configure(EntityTypeBuilder<Countries> builder)
        {
            base.Configure(builder);


            builder.HasKey(x => x.CountryId);
            builder.Property(x => x.CountryId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CountryName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsDateCreadCountry)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsRecurring)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Note)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ProveedorId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.StorId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.WhenDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CodeCountries)
                .IsUnicode(false); //Agregado 26/06/24


        }
    }
}
