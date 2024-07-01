using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class SendersEntityConfiguration : BasesEntityConfiguration<Senders>
    {
        public SendersEntityConfiguration()
        {
            TableName = "Senders";
        }

        public override void Configure(EntityTypeBuilder<Senders> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.SenderId);
            builder.Property(x => x.SenderId)
                .IsRequired();

            builder.Property(x => x.IsAsset)
                 .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsCreadSender)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.SenderName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.SenderPhone)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.IsModifiedSender)
                 .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.SenderCode)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.IsDeleted)
                 .IsUnicode(false);
                //.IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsModifiedPostalCode)
              .IsUnicode(false);
               // .IsRequired();

            builder.Property(x => x.SenderDirection)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired() ;
               
            builder.Property(x => x.SenderEmail)
                .IsUnicode(false)
                .HasMaxLength(180)
                .IsRequired();
                
            builder.Property(x => x.SenderPostalCode)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();            
        }
    }
}
