using UserNameApi.Models.DbModels;
using UserNameApi.Models.ViewModels;

namespace UserNameApi.Services;

public class WorkoutService
{
    private readonly WorkoutDbContext _dbContext;
    public WorkoutService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> StartNewWorkoutAsync()
    {
        long startDate = GetUnixTimeNow();

        var newWorkout = new Workout
        {
            StartDate = startDate
        };

        _dbContext.Workouts.Add(newWorkout);
        await _dbContext.SaveChangesAsync();
        return newWorkout.Id;
    }

    public async Task EndWorkoutAsync(long workoutId)
    {
        long endDate = GetUnixTimeNow();
        var workout = _dbContext.Workouts.SingleOrDefault(x => x.Id == workoutId);
        workout.EndDate = endDate;
        await _dbContext.SaveChangesAsync();
    }

    public WorkoutViewModel GetFullWorkoutInfo(long workoutId)
    {
        var result = _dbContext.Workouts
            .Include(x => x.WorkoutSessions)
            .SingleOrDefault(x => x.Id == workoutId);

        if (result is null) return null;

        var workoutSessions = result.WorkoutSessions
            .Select(session => _dbContext.WorkoutSessions
                .Include(x => x.WorkoutExcercise)
                .Include(x => x.WorkoutSets)
                .SingleOrDefault(x => x.Id == session.Id))
            .ToList();

        var viewModel = new WorkoutViewModel
        {
            Id = result.Id,
            StartDate = result.StartDate,
            EndDate = result.EndDate,
            WorkoutSessions = workoutSessions.Select(session => new WorkoutSessionViewModel
            {
                WorkoutExcerciseName = session.WorkoutExcercise.Name,
                WorkoutSets = session.WorkoutSets.Select(set => new WorkoutSetViewModel
                {
                    Weight = set.Weight,
                    Reps = set.Reps
                }).ToList()
            }).ToList()
        };

        return viewModel;
    }

    public List<WorkoutViewModel> GetAllFullWorkoutInfo()
    {
        var result = _dbContext.Workouts
            .Include(x => x.WorkoutSessions)
            .ToList();

        if (result is null) return null;


        var viewModels = result.Select(x => new WorkoutViewModel
        {
            Id = x.Id,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            WorkoutSessions = _dbContext.WorkoutSessions
                .Include(session => session.WorkoutExcercise)
                .Include(session => session.WorkoutSets)
                .Select(session => new WorkoutSessionViewModel
                {
                    WorkoutExcerciseName = session.WorkoutExcercise.Name,
                    WorkoutSets = session.WorkoutSets.Select(set => new WorkoutSetViewModel
                    {
                        Weight = set.Weight,
                        Reps = set.Reps
                    }).ToList()
                }).ToList()

        }).ToList();

        return viewModels;
    }

    public List<WorkoutViewModel> GetAllWorkoutsByExcerciseId(long excerciseId)
    {
        var sessionViewModels = _dbContext.WorkoutSessions
            .Include(session => session.WorkoutExcercise)
            .Include(session => session.WorkoutSets)
            .Where(session => session.WorkoutExcercise.Id == excerciseId)
            .Select(session => new WorkoutSessionViewModel
            {
                WorkoutExcerciseName = session.WorkoutExcercise.Name,
                WorkoutSets = session.WorkoutSets.Select(set => new WorkoutSetViewModel
                {
                    Weight = set.Weight,
                    Reps = set.Reps
                }).ToList()
            })
            .ToList();

        var result = _dbContext.Workouts
            .Include(workout => workout.WorkoutSessions)
            .Where(workout => workout.WorkoutSessions.Any(x => x.Id == excerciseId))
            .Select(workout => new WorkoutViewModel
            {
                Id = workout.Id,
                StartDate = workout.StartDate,
                EndDate = workout.EndDate,
                WorkoutSessions = sessionViewModels
            })
            .ToList();

        return result;
    }

    public async Task RemoveWorkoutAsync(long workoutId)
    {
        _dbContext.Workouts.Remove(_dbContext.Workouts.SingleOrDefault(x => x.Id == workoutId));
        await _dbContext.SaveChangesAsync();
    }

    #region Private

    private long GetUnixTimeNow()
    {
        DateTime now = DateTime.UtcNow;
        long result = ((DateTimeOffset)now).ToUnixTimeSeconds();
        return result;
    }

    #endregion
}