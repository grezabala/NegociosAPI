using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class ProveedoresEntityConfiguration : BasesEntityConfiguration<Proveedores>
    {
        public ProveedoresEntityConfiguration()
        {
            TableName = "Proveedores";
        }

        public override void Configure(EntityTypeBuilder<Proveedores> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.ProveedorId);

            builder.Property(x => x.ProveedorId)
                .IsRequired();

            builder.Property(x => x.CreadProveedor)
                 .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsAsset)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDateModified)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false);
               // .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsModified)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsDateModified)
                .IsUnicode(false);

            builder.Property(x => x.ProveedorCode)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ProveedorDescription)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();
              
            builder.Property(x => x.ProveedorReference)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.ProveedorDirection)
               .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.ProveedorName)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
