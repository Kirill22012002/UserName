using Microsoft.EntityFrameworkCore;
using UserNameApi.Models.DbModels;

namespace UserNameApi.Services;

public class WorkoutSetService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutSetService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> AddSetAsync(double weight, int reps, long workoutSessionId)
    {
        var newModel = new WorkoutSet
        {
            Weight = weight,
            Reps = reps
        };

        var session = _dbContext.WorkoutSessions
            .Include(x => x.WorkoutSets)
            .SingleOrDefault(x => x.Id == workoutSessionId);

        session.WorkoutSets.Add(newModel);

        _dbContext.WorkoutSets.Add(newModel);
        await _dbContext.SaveChangesAsync();
        return newModel.Id;
    }
}
