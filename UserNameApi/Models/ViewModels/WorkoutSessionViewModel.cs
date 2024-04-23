using UserNameApi.Models.DbModels;

namespace UserNameApi.Models.ViewModels;

public class WorkoutSessionViewModel
{
    public string WorkoutExcerciseName { get; set; }
    public List<WorkoutSetViewModel> WorkoutSets { get; set; } = new List<WorkoutSetViewModel>();
}