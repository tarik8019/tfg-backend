using ApiRest.Application.Interfaces;
using ApiRest.AutoMapper;
using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository;
using ApiRest.Repository.IRepository;
using ApiRest.Services;
using ApiRest.Services.EmailServices;
using ApiRest.Services.GeoService;
using ApiRest.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Db connection config
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISolicitudAusenciaRepository, SolicitudAusenciaRepository>();
builder.Services.AddScoped<IAsignacionTurnoRepository, AsignacionTurnoRepository>();
builder.Services.AddScoped<ICorreccionFichajeRepository, CorreccionFichajeRepository>();
builder.Services.AddScoped<IDisponibilidadRepository, DisponibilidadRepository>();
builder.Services.AddScoped<IDocumentoEmpleadoRepository, DocumentoEmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IFichajeRepository, FichajeRepository>();
builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<IReglaTurnoRepository, ReglaTurnoRepository>();
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<ISedeRepository, SedeRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>(); 
builder.Services.AddScoped<IGeoService, GeoService>();
builder.Services.AddScoped<IFichajeService, FichajeService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<SeederService>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

//Logger setup
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// builder cache
builder.Services.AddMemoryCache();

//.Net Identity Configuration
//builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//Setting Authentication Code
var key = builder.Configuration.GetValue<string>("ApiSettings:SecretKey");

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//Required for Authorization
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(
                new JsonStringEnumConverter()
            );
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Auth Bearer Token \r\n\r\n" +
        "Insert The token with the following format: Bearer thgashqkssuqj",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer"
            },
            new List<string>()
        }
    });
});




//CORS Policy

builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
{
    //CORS no aplica, porque las apps móviles no usan navegador.
    //Solo importa si estoy usando Flutter Web.
    // Aquí defino qué dominios tienen permiso para llamar a mi API desde el navegador.
    build.WithOrigins(
        "http://localhost:5173",
        "https://fountainlike-habitably-jovan.ngrok-free.dev")
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials();  // Muy importante para permitir cookies y headers con credenciales
}));


//builder.WebHost.ConfigureKestrel(options =>
//{
    //options.Listen(System.Net.IPAddress.Loopback, 5072, listenOptions =>
    //{
        //listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
    //});
//});





//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequiredLength = 8;
//});


var app = builder.Build();

// Ejecutar seeder
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SeederService>();
    await seeder.SeedAsync();
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Ve a Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes.
// Add-Migration InitialCreate
// Update-Database

// dotnet ef migrations add InitialCreate
// dotnet ef database update 

//dotnet ef migrations remove 
//dotnet tool install 
// dotnet clean
// dotnet build





/*
//Create Container
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=jS7R4qwUYx9e6uM5k8Zhfv' -e "MSSQL_PID=Developer"
  -p 1400:1433 
  --name SQL_Server_DI
  -v SQL_Server_Volume:/var/opt/mssql
  -d mcr.microsoft.com/mssql/server:2022-latest


//Create User
-- Step 1: Create a SQL Login
CREATE LOGIN api_user
WITH PASSWORD = 'jS7R4qwUYx9e6uM5k8Zhfv'; -- Replace with a strong password

CREATE USER api_user
FOR LOGIN api_user;

-- Step 2: Create a Database User for MovieAPI
USE Basic;

CREATE USER AppUser
FOR LOGIN api_user;

-- Step 3: Grant CRUD permissions to the user
-- Grant permissions on the schema or specific tables
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO AppUser;

-- Alternatively, grant db_datawriter and db_datareader roles
-- db_datareader: Can read all data in the database
-- db_datawriter: Can write to all data in the database
EXEC sp_addrolemember 'db_datareader', 'api_user';
EXEC sp_addrolemember 'db_datawriter', 'api_user';

-- Step 4: Grant ALTER and CREATE permissions for handling migrations
GRANT ALTER ON SCHEMA::dbo TO AppUser; -- For altering existing objects
GRANT REFERENCES ON SCHEMA::dbo TO AppUser;
GRANT CREATE TABLE TO api_user;        -- For creating new tables
GRANT CREATE PROCEDURE TO api_user;    -- For creating stored procedures
GRANT CREATE VIEW TO api_user;         -- For creating views

-- Step 5: Optionally grant execution permission if needed
GRANT EXECUTE ON SCHEMA::dbo TO api_user;

*/

// Rafa version
/*
//Create Container
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=wnD/LbJq?X39t,}-628%)' -e "MSSQL_PID=Developer"
  -p 1433:1433 
  --name SQL_Server_DI
  -v SQL_Server_Volume:/var/opt/mssql
  -d mcr.microsoft.com/mssql/server:2022-latest


//Create User
-- Step 1: Create a SQL Login
CREATE LOGIN AppUserLogin
WITH PASSWORD = 'e.d_fwm2()~37hz?+LBT4V'; -- Replace with a strong password

CREATE USER AppUser
FOR LOGIN AppUserLogin;

-- Step 2: Create a Database User for MovieAPI
CREATE DATABASE Basic;
USE Basic;

CREATE USER AppUser
FOR LOGIN AppUserLogin;

-- Step 3: Grant CRUD permissions to the user
-- Grant permissions on the schema or specific tables
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO AppUser;

-- Alternatively, grant db_datawriter and db_datareader roles
-- db_datareader: Can read all data in the database
-- db_datawriter: Can write to all data in the database
EXEC sp_addrolemember 'db_datareader', 'AppUser';
EXEC sp_addrolemember 'db_datawriter', 'AppUser';

-- Step 4: Grant ALTER and CREATE permissions for handling migrations
GRANT ALTER ON SCHEMA::dbo TO AppUser; -- For altering existing objects
GRANT REFERENCES ON SCHEMA::dbo TO AppUser;
GRANT CREATE TABLE TO AppUser;        -- For creating new tables
GRANT CREATE PROCEDURE TO AppUser;    -- For creating stored procedures
GRANT CREATE VIEW TO AppUser;         -- For creating views

-- Step 5: Optionally grant execution permission if needed
GRANT EXECUTE ON SCHEMA::dbo TO AppUser;

*/


