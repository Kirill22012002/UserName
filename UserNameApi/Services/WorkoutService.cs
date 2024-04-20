using Microsoft.EntityFrameworkCore;
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

    public async Task AddNewSessionToWorkoutAsync(long sessionId, long workoutId)
    {
        var session = _dbContext.WorkoutSessions.SingleOrDefault(x => x.Id == sessionId);
        var workout = _dbContext.Workouts.SingleOrDefault(x => x.Id == workoutId);

        workout.WorkoutSessions.Add(session);
        await _dbContext.SaveChangesAsync();
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
                Id = session.Id,
                WorkoutExcerciseName = session.WorkoutExcercise.Name,
                WorkoutSets = session.WorkoutSets.Select(set => new WorkoutSetViewModel
                {
                    Id = set.Id,
                    Weight = set.Weight,
                    Reps = set.Reps
                }).ToList()
            }).ToList()
        };
        
        return viewModel;
    }

    private long GetUnixTimeNow()
    {
        DateTime now = DateTime.UtcNow;
        long result = ((DateTimeOffset)now).ToUnixTimeSeconds();
        return result;
    }
}