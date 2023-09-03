using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class ProductosEntityConfiguration : BasesEntityConfiguration<Productos>
    {
        public ProductosEntityConfiguration()
        {
            TableName = "Productos";
        }

        public override void Configure(EntityTypeBuilder<Productos> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId)
                .IsUnicode(false)
                .IsRequired();


            builder.Property(x => x.IsAsset)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsApproved)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsUnicode(false)
                .HasColumnType("Decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Description)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.IsApproved)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.ProductName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsUnicode(false)
                .IsRequired();
        }
    }

}
