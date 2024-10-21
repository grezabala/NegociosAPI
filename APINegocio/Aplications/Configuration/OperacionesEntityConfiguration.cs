using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class OperacionesEntityConfiguration : BasesEntityConfiguration<Operaciones>
    {
        public OperacionesEntityConfiguration()
        {
            TableName = typeof(Operaciones).Name;
        }

        public override void Configure(EntityTypeBuilder<Operaciones> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.OperacionId);

            builder.Property(x => x.Tipo)
                  .IsUnicode(false)
                  .HasMaxLength(100)
                  .IsRequired();

            builder.Property(x => x.Producto)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Fecha)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.Cantidad)
                .IsUnicode (false)
                .IsRequired();

            builder.Property(x => x.Stock)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(x => x.IsDeletedBy)
                .IsUnicode(false);

            builder.HasQueryFilter(x => !x.IsDeletedBy);

            builder.Property(x => x.IsDeletedAt)
               .IsUnicode(false);

            builder.Property(x => x.IsUpdatedBy)
                 .IsUnicode(false);

            builder.Property(x => x.IsUpdatedAt)
                 .IsUnicode(false);

            builder.Property(x => x.IsStatu)
                 .IsUnicode(false)
                 .IsRequired();

        }
    }
}
