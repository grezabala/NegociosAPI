using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class InventoryEntityConfiguration : BasesEntityConfiguration<Inventory>
    {
        public InventoryEntityConfiguration()
        {
            TableName = "Inventory"; //typeof(Inventory).Name;
        }

        public override void Configure(EntityTypeBuilder<Inventory> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.InventoryId);
            builder.Property(x => x.InventoryId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.InventoryName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.DescrictionInventory)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.ReferenceInventory)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.NumberInventory)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CodigoInventory)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DateCread)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDateCread)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);

            builder.Property(x => x.IsUpdated)
                .IsUnicode(false);

            builder.Property(x => x.IsUpdatedAt)
                .IsUnicode(false);

            builder.Property(x => x.IsShipped)
                .IsUnicode(false);

            builder.Property(x => x.ShoppingId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.StoreId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.ProductoId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.ProveedorId)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}
