using Microsoft.EntityFrameworkCore;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class OrdersEntityConfiguration : BasesEntityConfiguration<Orders>
    {
        public OrdersEntityConfiguration()
        {
            TableName = "Orders";
        }
        public override void Configure(EntityTypeBuilder<Orders> builder)
        {
            base.Configure(builder);    

            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.SenderId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.DateOrder)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsAsset)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsCread)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsCreadOrderDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModified)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModifiedOrderDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.OrderCode)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
