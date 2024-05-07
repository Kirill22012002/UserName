using UserNameApi.Models.DbModels;

namespace UserNameApi.Persistence.Repositories;

public class WorkoutSessionRepository : BaseRepository<WorkoutSession, WorkoutDbContext>
{
    public WorkoutSessionRepository(WorkoutDbContext dbContext) : base(dbContext) { }
}
