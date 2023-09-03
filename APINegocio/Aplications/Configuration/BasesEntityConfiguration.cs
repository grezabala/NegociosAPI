using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINegocio.Aplications.Configuration
{
    public abstract class BasesEntityConfiguration<TEntity>  : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public string? Schema { get; set; }
        public string? TableName { get; set; }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if(string.IsNullOrEmpty(this.TableName))
                throw new ArgumentNullException(null, nameof(TableName));

            builder.ToTable(TableName, schema: Schema);          
        }
    }
}
