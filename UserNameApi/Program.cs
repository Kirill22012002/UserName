using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UserNameApi;
using UserNameApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes("my_custom_secret");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://username",
            ValidAudience = "https://username",
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.NameIdentifier);
    });
});

string dbConnectionString;
if (Environment.GetEnvironmentVariable("Environment") == "Production")
{
    dbConnectionString = Environment.GetEnvironmentVariable("DbConnection");
}
else
{
    dbConnectionString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=changeme";
}

builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseNpgsql(dbConnectionString));

builder.Services.AddTransient<DataSeeder>();
builder.Services.AddTransient<WorkoutExcerciseService>();
builder.Services.AddTransient<WorkoutSetService>();
builder.Services.AddTransient<WorkoutSessionService>();
builder.Services.AddTransient<WorkoutService>();
builder.Services.AddTransient<UserService>();

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