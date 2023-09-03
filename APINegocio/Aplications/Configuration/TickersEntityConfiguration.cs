using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class TickersEntityConfiguration : BasesEntityConfiguration<Tickers>
    {
        public TickersEntityConfiguration()
        {
            TableName = "Tickers";
        }

        public override void Configure(EntityTypeBuilder<Tickers> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.TickerId);
            builder.Property(x => x.TickerId)
                .IsRequired();

            builder.Property(x => x.CashierName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.Direction)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.NIF)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Pago)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.RNC)
                 .IsUnicode(false)
                 .IsRequired();

            builder.Property(x => x.TickerTitulo)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.TotalAmountItbis)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalAmountPay)
                .IsUnicode(false)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalProduct)
                 .IsUnicode(false)
                 .IsRequired();

            builder.Property(x => x.TransactionNumber)
                 .IsUnicode(false)
                 .IsRequired();

            builder.Property(x => x.CodeTicker)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsLocked)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModified)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModifiedDate)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsImprection)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.DateImprect)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
