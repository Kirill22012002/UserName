using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UserNameApi;
using UserNameApi.Models.DbModels;
using UserNameApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<WorkoutDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false; 
    options.Password.RequireUppercase = false; 
    options.Password.RequireNonAlphanumeric = false; 
    options.Password.RequiredLength = 8; 
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "JwtIssuer",
            ValidAudience = "JwtIssuer",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtKey"))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
});

string dbConnectionString;
if (Environment.GetEnvironmentVariable("ENVIRONMENT") == "Production")
{
    dbConnectionString = Environment.GetEnvironmentVariable("PG_CONNECTION_STRING");
}
else
{
    //dbConnectionString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=changeme";
    dbConnectionString = "Host=79.174.88.22;Port=15679;Database=usernamedb;Username=username;Password=DaFnA300012*HJYhnaskjha7324kjh)";
}

builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseNpgsql(dbConnectionString));

builder.Services.AddTransient<DataSeeder>();
builder.Services.AddTransient<WorkoutExcerciseService>();
builder.Services.AddTransient<WorkoutSetService>();
builder.Services.AddTransient<WorkoutSessionService>();
builder.Services.AddTransient<WorkoutService>();

var app = builder.Build();

SeedData(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}