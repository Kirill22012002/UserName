using UserNameApi.Models.DbModels;

namespace UserNameApi.Services;

public class WorkoutSetService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutSetService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> AddSetAsync(double weight, int reps)
    {
        var newModel = new WorkoutSet
        {
            Weight = weight,
            Reps = reps
        };

        _dbContext.WorkoutSets.Add(newModel);
        await _dbContext.SaveChangesAsync();
        return newModel.Id;
    }
}
