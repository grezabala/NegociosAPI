using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class PaymentsEntityConfiguration : BasesEntityConfiguration<Payments>
    {
        public PaymentsEntityConfiguration()
        {
            TableName = "Payments";
        }

        public override void Configure(EntityTypeBuilder<Payments> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.PaymentId);
            builder.Property(x => x.PaymentId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Aplicado)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Creditado)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Fecha)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsCreadtPayment)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsCreadtRefund)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false);
               // .IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsRefund)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsUpdated)
                .IsUnicode(false);
            // .IsRequired();

            builder.Property(x => x.IsUpdatedAt)
                .IsUnicode(false);
               // .IsRequired();

            builder.Property(x => x.Monto)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.OrderId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Reservado)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Toquen)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.PaymentCode)
                .IsUnicode(false); //Agregado 26/06/24
        }
    }
}
