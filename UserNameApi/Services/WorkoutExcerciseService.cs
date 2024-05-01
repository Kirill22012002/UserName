using UserNameApi.Models.DbModels;
using UserNameApi.Models.ViewModels;

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

    public async Task<List<WorkoutExcerciseViewModel>> GetAllExcercisesAsync()
    {
        var excercisesDb = await _dbContext.WorkoutExcercises.ToListAsync();
        var result = excercisesDb.Select(excercise => new WorkoutExcerciseViewModel
        {
            Id = excercise.Id,
            Name = excercise.Name,
            Description = excercise.Description
        }).ToList();

        return result;
    }

    public async Task<WorkoutExcercise> GetExcerciseByIdAsync(long id)
    {
        return await _dbContext.WorkoutExcercises.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<string> ChangeExcerciseNameAsync(long id, string newName)
    {
        var excercise = _dbContext.WorkoutExcercises
            .SingleOrDefault(excercise => excercise.Id == id);

        excercise.Name = newName;
        await _dbContext.SaveChangesAsync();
        return excercise.Name;
    }

    public async Task<string> ChangeExcerciseDescripionAsync(long id, string newDescription)
    {
        var excercise = _dbContext.WorkoutExcercises
            .SingleOrDefault(excercise => excercise.Id == id);

        excercise.Description = newDescription;
        await _dbContext.SaveChangesAsync();
        return excercise.Description;
    }
}