namespace UserNameApi.Models.DbModels;

public class Workout : BaseModel
{
    public long StartDate { get; set; }
    public long EndDate { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}