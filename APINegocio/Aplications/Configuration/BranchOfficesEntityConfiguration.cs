using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class BranchOfficesEntityConfiguration : BasesEntityConfiguration<BranchOffices>
    {
        public BranchOfficesEntityConfiguration()
        {
            TableName = "BranchOffices";
        }

        public override void Configure(EntityTypeBuilder<BranchOffices> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.BranchId);
            builder.Property(e => e.BranchId)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.BranchOfficesName)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasMaxLength(550)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.BranchOfficesCode)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(350)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Contacts)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Referencia)
                .HasMaxLength(550)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.WebSite)
                .HasMaxLength(350)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.FacebookAccount)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.InstagramAccount)
               .HasMaxLength(250)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.WhatsAppNumber)
               .HasMaxLength(250)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
               .HasMaxLength(80)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.OtherNumber)
              .HasMaxLength(80)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.Latitud)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.Longitud)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.IsDeletedAt)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsDeletedAt)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.IsCreadBy)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.IsCreadAt)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsDeletedAt)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsDeletedBy)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsUpdatedBy)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsUpdatedAt)
              .IsRequired()
              .IsUnicode(false);

            builder.Property(e => e.IsStatud)
             .IsRequired()
             .IsUnicode(false);
        }
    }
}
