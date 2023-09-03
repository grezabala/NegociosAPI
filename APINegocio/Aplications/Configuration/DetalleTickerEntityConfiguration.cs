using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class DetalleTickerEntityConfiguration : BasesEntityConfiguration<DetalleTicker>
    {
        public DetalleTickerEntityConfiguration()
        {
            TableName = "DetalleTickers";
        }

        public override void Configure(EntityTypeBuilder<DetalleTicker> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.DetalleId);
            builder.Property(x => x.DetalleId)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.CustomerId)
                .IsUnicode(false)
                .IsRequired();
              
            builder.Property(x => x.ProductId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Descounts)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Itbis)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalDescout)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalItbis)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalPagar)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.LastUpdated)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModified)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(x => x.IsModifiedDate)
               .IsUnicode(false)
               .IsRequired();
        }
    }
}
