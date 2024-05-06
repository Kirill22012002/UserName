using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserNameApi.Models.DbModels;

namespace UserNameApi;

public class WorkoutDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<WorkoutExcercise> WorkoutExcercises { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}