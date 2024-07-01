using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class UserEntityConfiguration : BasesEntityConfiguration<Users>
    {
        public UserEntityConfiguration()
        {
            TableName = "Users";
        }

        public override void Configure(EntityTypeBuilder<Users> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.UserName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Email)
               .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted);

            builder.Property(e => e.IsAsset)
               .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.LastModifiedDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.CreatedDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.LastModifiedDateUtc)
                .IsUnicode(false);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();

                
        }
    }
}
