using UserNameApi.Models.DbModels;

namespace UserNameApi.Persistence.Repositories;

public class WorkoutExcerciseRepository : BaseRepository<Workout, WorkoutDbContext>
{
    public WorkoutExcerciseRepository(WorkoutDbContext dbContext) : base(dbContext) { }
}
