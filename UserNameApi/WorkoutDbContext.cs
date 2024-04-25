using UserNameApi.Models.DbModels;

namespace UserNameApi;

public class WorkoutDbContext : DbContext
{
    public DbSet<WorkoutExcercise> WorkoutExcercises { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public DbSet<User> Users { get; set; }

    public WorkoutDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}