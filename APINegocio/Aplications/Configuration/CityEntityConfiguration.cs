using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class CityEntityConfiguration : BasesEntityConfiguration<City>
    {
        public CityEntityConfiguration()
        {
            TableName = "City";
        }

        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.CityId);
            builder.Property(x => x.CityId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CountryId)
                .IsUnicode(false)
                .IsUnicode();

            builder.Property(x => x.CityName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Code)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false);
                //.IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsUpdateAt)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsUpdated)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsStatus)
                .IsUnicode(false)
                .IsRequired();
      
        }
    }
}
