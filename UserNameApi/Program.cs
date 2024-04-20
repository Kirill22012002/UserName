using Microsoft.EntityFrameworkCore;
using UserNameApi;
using UserNameApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = Environment.GetEnvironmentVariable("DbConnection");

builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(dbConnectionString)));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
