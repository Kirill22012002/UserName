using Microsoft.EntityFrameworkCore;
using UserNameApi.Models.DbModels;

namespace UserNameApi.Services;

public class WorkoutExcerciseService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutExcerciseService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> AddExcerciseAsync(string name, string description)
    {
        var newExcercise = new WorkoutExcercise()
        {
            Name = name,
            Description = description
        };

        _dbContext.WorkoutExcercises.Add(newExcercise);
        await _dbContext.SaveChangesAsync();
        return newExcercise.Id;
    }

    public async Task<List<WorkoutExcercise>> GetAllExcercisesAsync()
    {
        return await _dbContext.WorkoutExcercises.ToListAsync();
    }

    public async Task<WorkoutExcercise> GetExcerciseByIdAsync(long id)
    {
        return await _dbContext.WorkoutExcercises.SingleOrDefaultAsync(x => x.Id == id);
    }

}
