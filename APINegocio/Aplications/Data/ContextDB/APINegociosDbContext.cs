using APINegocio.Aplications.Authentication;
using APINegocio.Aplications.Configuration;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Services.Interfaz.IContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APINegocio.Aplications.Data.ContextDB
{
    public partial class APINegociosDbContext :  IdentityDbContext<ApplicationUser>, IAPINegocioDbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public APINegociosDbContext(DbContextOptions<APINegociosDbContext> contextOptions)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(contextOptions)
        {

        }

        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Shopping> Shoppings { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Senders> Senders { get; set; }
        public virtual DbSet<DetalleTicker> DetalleTickers { get; set; }
        public virtual DbSet<Tickers> Tickers { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(BasesEntityConfiguration<>).Assembly);

            OnModelCreatingPartial(builder);

            base.OnModelCreating(builder);
        }
        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
