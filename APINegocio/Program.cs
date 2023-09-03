using APINegocio.Aplications.IoCExtensions;


//IConfiguration Configuration; 
var builder = WebApplication.CreateBuilder(args);

// = builder.Configuration;
var Configuration = builder.Configuration;
// Add services to the container.
//Llamada a los servicios
builder.Services.ConfigurationServicesDb(Configuration);
builder.Services.AddAPINegocioService();
//builder.Services.AddAPINegocioService();
//builder.Services.TokenAPINegocio(Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

builder.Services.AddRazorPages();

builder.Services.AddMvcCore();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthorization();
//Llamada a los servicios
//builder.Services.ConfigurationServicesDb(Configuration);

builder.Services.TokenAPINegocio(Configuration);


//builder.Services.ConfigurationServices();
