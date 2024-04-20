using Microsoft.EntityFrameworkCore;
using UserNameApi.Models.DbModels;

namespace UserNameApi.Services;

public class WorkoutSessionService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutSessionService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> AddNewSessionAsync(long excerciseId)
    {
        var excercise = await _dbContext.WorkoutExcercises
            .SingleOrDefaultAsync(x => x.Id == excerciseId);

        var newSession = new WorkoutSession
        {
            WorkoutExcercise = excercise,
        };

        _dbContext.WorkoutSessions.Add(newSession);
        await _dbContext.SaveChangesAsync();
        return newSession.Id;
    }

    public async Task AddSetToSessionAsync(long setId, long sessionId)
    {
        var session = await _dbContext.WorkoutSessions.SingleOrDefaultAsync(x => x.Id == sessionId);
        var set = await _dbContext.WorkoutSets.SingleOrDefaultAsync(x => x.Id == setId);

        session.WorkoutSet.Add(set);
        await _dbContext.SaveChangesAsync();
    }
}
