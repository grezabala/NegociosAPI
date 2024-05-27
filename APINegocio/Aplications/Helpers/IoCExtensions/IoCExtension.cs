using APINegocio.Aplications.Authentication.Repository;
using APINegocio.Aplications.Configuration;
using APINegocio.Aplications.Mappers;
using APINegocio.Aplications.Services;
using APINegocio.Aplications.Services.Interfaz;
using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Interfaz;
using APINegocio.Aplications.Services.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APINegocio.Aplications.Services.Interfaz.IContext;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Data.Services.Repository;
using APINegocio.Aplications.Authentication.Interfaz;

namespace APINegocio.Aplications.IoCExtensions
{
    public static class IoCExtension
    {
        public static IConfiguration? Configuration { get; }

        //Configuration service Token
        public static IServiceCollection TokenAPINegocio(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration!["TokenKey"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };

            });

            return services;
        }

        //Add Conection Data Base Service
        public static IServiceCollection ConfigurationServicesDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<APINegociosDbContext>(db =>
            {
                db.UseSqlServer(@"Data Source=(local); Initial Catalog=NegocioDb; Integrated Security=True; MultipleActiveResultSets=True; Encrypt=False", sql =>
                {
                    sql.EnableRetryOnFailure();
                    sql.UseNetTopologySuite();
                    sql.MigrationsAssembly(typeof(BasesEntityConfiguration<>).Assembly.GetName().Name);

                });

                db.UseLazyLoadingProxies();
            });

            services.AddScoped<IAPINegocioDbContext>(set => set.GetService<APINegociosDbContext>()!);
            //services.AddScoped<APINegociosDbContext>();
            return services;

            //services.AddDbContext<APINegociosDbContext>(db =>
            //{
            //    db.UseLazyLoadingProxies();
            //    db.UseSqlServer(Configuration.GetConnectionString("APINegociosDbContext"));

            //});
            //services.AddScoped<IAPINegocioDbContext>(set => set.GetService<APINegociosDbContext>()!);
            //return services;
            //services.AddScoped<APINegociosDbContext>();
            //return services;
        }

        //Add Service
        public static IServiceCollection AddAPINegocioService(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddScoped(typeof(ITokenServices), typeof(TokenService));
            services.AddScoped<IAuthenticationAIPNegocio, RepoAuthenticationAIPNegocio>();
            services.AddScoped(typeof(ILogisticaService), typeof(LogisticaService));
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped(typeof(IBranchOfficesService), typeof(BranchOfficesService));

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly); //PARA LA INJENCCION DE AUTOMAPPER

            return services;

        }

        public static IServiceCollection ConfigurationServices(this IServiceCollection services)
        {
            //services.AddDbContext<IAPINegocioDbContext, APINegociosDbContext>();
            return services;
        }

    }
}
