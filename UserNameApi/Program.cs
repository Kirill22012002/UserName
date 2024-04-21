using UserNameApi;
using UserNameApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = Environment.GetEnvironmentVariable("DbConnection");

//string dbConnectionString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=changeme";

builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseNpgsql(dbConnectionString));

builder.Services.AddTransient<WorkoutExcerciseService>();
builder.Services.AddTransient<WorkoutSetService>();
builder.Services.AddTransient<WorkoutSessionService>();
builder.Services.AddTransient<WorkoutService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
