using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class ShoppingEntityConfiguration : BasesEntityConfiguration<Shopping>
    {
        public ShoppingEntityConfiguration()
        {
            TableName = "Shopping";
        }

        public override void Configure(EntityTypeBuilder<Shopping> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.ShoppingId);
            builder.Property(x => x.ShoppingId)
                .IsRequired();

            builder.Property(x => x.IsAsset)
                 .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                  .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModifedShopping)
                 .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModified)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsShoppingDate)
                 .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NumberShopping)
                .IsUnicode(false)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.ShoppingCode)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.ShoppingCount)
                .IsUnicode(false)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.ShoppingDescription)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.ShoppingName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ShoppingStatus)
                .IsUnicode(false)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.ShoppingTitle)
               .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
