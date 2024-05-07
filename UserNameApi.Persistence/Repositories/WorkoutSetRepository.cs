using UserNameApi.Models.DbModels;

namespace UserNameApi.Persistence.Repositories;

public class WorkoutSetRepository : BaseRepository<WorkoutSet, WorkoutDbContext>
{
    public WorkoutSetRepository(WorkoutDbContext dbContext) : base(dbContext) { }
}
