using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;

namespace APINegocio.Aplications.Services.Interfaz.IContext
{
    public interface IAPINegocioDbContext
    {
        DbSet<Productos> Productos { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Proveedores> Proveedores { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Shopping> Shoppings { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Senders> Senders { get; set; }
        DbSet<DetalleTicker> DetalleTickers { get; set; }
        DbSet<Tickers> Tickers { get; set; }
        DbSet<City> City { get; set; }
        DbSet<Countries> Countries { get; set; }
        DbSet<Payments> Payments { get; set; }
        DbSet<Stores> Stores { get; set; }
        DbSet<Inventory> Inventory { get; set; }
        DbSet<BranchOffices> BranchOffices { get; set; }
    }
}
