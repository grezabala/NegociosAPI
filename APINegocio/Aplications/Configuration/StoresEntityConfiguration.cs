using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public class StoresEntityConfiguration : BasesEntityConfiguration<Stores>
    {
        public StoresEntityConfiguration()
        {
            TableName = "Stores";
        }


        public override void Configure(EntityTypeBuilder<Stores> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.StorId);

            builder.Property(x => x.StorId)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.StoresName)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Stock)
                .IsUnicode(); //Agregado el 27/06/24

            builder.Property(x => x.CodeStore)
                .IsUnicode(false); //Agregado el 27/06/24

            builder.Property(x => x.AceptPyments)
                .IsUnicode(false)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Address)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Biography)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.FacebookAccount)
                .IsUnicode(false)
                .HasMaxLength(250);
                //.IsRequired();

            builder.Property(x => x.InstagramAccount)
                .IsUnicode(false)
                .HasMaxLength(250);
                //.IsRequired();

            builder.Property(x => x.IsCreadDateStore)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsUnicode(false);
                //.IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.IsModified)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.Latitud)
                .IsUnicode(false)
                .HasMaxLength(250);
                
            builder.Property(x => x.Longitud)
                .IsUnicode(false)
                .HasMaxLength(250);

            builder.Property(x => x.OtherNumber)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.StoresCount)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.StoresDescription)
                .IsUnicode(false)
                .HasMaxLength(550)
                .IsRequired();

            builder.Property(x => x.StoresTotal)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.WebSite)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.WhatsAppNumber)
                .IsUnicode(false);
            //.IsRequired();

            builder.Property(x => x.IsDeletedAt)
                .IsUnicode(false);
                //.IsRequired();

            builder.Property(x => x.IsStatud)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.IsModifiedBy)
                .IsUnicode(false);
        }
    }
}
