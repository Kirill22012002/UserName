using UserNameApi.Models.DbModels;

namespace UserNameApi.Persistence.Repositories;

public class WorkoutRepository : BaseRepository<Workout, WorkoutDbContext>
{
    public WorkoutRepository(WorkoutDbContext dbContext) : base(dbContext) { }
}
