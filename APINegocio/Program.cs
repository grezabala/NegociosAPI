using APINegocio.Aplications.Data_Sqlite;
using APINegocio.Aplications.Helpers.Filters;
using APINegocio.Aplications.IoCExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


//IConfiguration Configuration; 
var builder = WebApplication.CreateBuilder(args);

// = builder.Configuration;
var Configuration = builder.Configuration;

//CONNECTION A SQLITE
builder.Services.AddDbContext<DataDbContext>(x =>
{
    x.UseLazyLoadingProxies();
    x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
});


// Add services to the container.
//Llamada a los servicios
builder.Services.ConfigurationServicesDb(Configuration);
builder.Services.AddAPINegocioService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APINegocio", Version = "v1" });

    c.AddSecurityDefinition("Users", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "Authorization Key",

    });

    c.OperationFilter<AuthResponsesOperationFilter>();

    var security = new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Users",
                    Type = ReferenceType.SecurityScheme

                },
                UnresolvedReference = true
            },
    new List<string>()
            }
    };

    c.AddSecurityRequirement(security);
});

//Configuracion para el Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op =>
    {
        op.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,

        };

    });

builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APINegocio.API v1"));
}

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseStatusCodePages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

builder.Services.AddRazorPages();

builder.Services.AddMvcCore();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

//builder.Services.TokenAPINegocio(Configuration);

#region VER
/*
 PARA LA CONEXION A LA BASE DE DATO DE FREESQLDATABASE
Host: sql10.freesqldatabase.com
Database name: sql10645379
Database user: sql10645379
Database password: Fw9K2BszKr
Port number: 3306
 
//builder.Services.ConfigurationServices();

//builder.Services.AddAuthorization();
//Llamada a los servicios
//builder.Services.ConfigurationServicesDb(Configuration);


//INSTALAR EL PAQUETE Microsoft.EntityFremeworkCore.Proxies PARA TRABAJAR CON UseLazyLoadingProxies y UseSqlite 
//Microsoft.AspNetCore.Mvc.NewtonsoftJson ---middleware para una api rest c#
//PAQUETE PARA LA AUTORIZACION DE SWAGGER Swashbuckle.AspNetCore


//builder.Services.AddAPINegocioService();
//builder.Services.TokenAPINegocio(Configuration);

Correo Gmail

melendezruizgregorio@gmail.com

Password:
@@@14Ar###

Password FreeSQLdatabase:
@@@freeDataBase01

 */
#endregion