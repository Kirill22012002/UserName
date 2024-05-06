using UserNameApi.Models.DbModels;

namespace UserNameApi.Services;

public class WorkoutSessionService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutSessionService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> AddNewSessionAsync(ApplicationUser user, long excerciseId)
    {
        var currentWorkout = _dbContext.Workouts.SingleOrDefault(x => x.Id == user.CurrentWorkoutId);
        var excercise = _dbContext.WorkoutExcercises.SingleOrDefault(x => x.Id == excerciseId);

        var newSession = new WorkoutSession
        {
            WorkoutExcercise = excercise,
        };

        _dbContext.WorkoutSessions.Add(newSession);
        currentWorkout.WorkoutSessions.Add(newSession);
        await _dbContext.SaveChangesAsync();

        user.CurrentSessionId = newSession.Id;
        await _dbContext.SaveChangesAsync();

        return newSession.Id;
    }

    public async Task AddSetToSessionAsync(long setId, long sessionId)
    {
        var session = _dbContext.WorkoutSessions.SingleOrDefault(x => x.Id == sessionId);
        var set = _dbContext.WorkoutSets.SingleOrDefault(x => x.Id == setId);

        session.WorkoutSets.Add(set);
        await _dbContext.SaveChangesAsync();
    }
}
