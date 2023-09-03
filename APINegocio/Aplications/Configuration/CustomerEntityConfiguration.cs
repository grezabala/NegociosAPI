using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class CustomerEntityConfiguration : BasesEntityConfiguration<Customers>
    {
        public CustomerEntityConfiguration()
        {
            TableName = "Customers";
        }

        public override void Configure(EntityTypeBuilder<Customers> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId)
                .IsUnicode(false)
                .IsRequired();
            
            builder.Property(x => x.CustomerName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.City)
                .IsUnicode(false)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Country)
                .IsUnicode(false)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CustomerEmail)
                .IsUnicode(false)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.CustomerPhone)
                .IsUnicode(false)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Direction)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModified)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsStatu)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsUpdatedDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .IsUnicode(false)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
