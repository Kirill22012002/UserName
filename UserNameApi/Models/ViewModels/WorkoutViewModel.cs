using UserNameApi.Models.DbModels;

namespace UserNameApi.Models.ViewModels;

public class WorkoutViewModel
{
    public long Id { get; set; }
    public long StartDate { get; set; }
    public long EndDate { get; set; }
    public List<WorkoutSessionViewModel> WorkoutSessions { get; set; } = new List<WorkoutSessionViewModel>();
}