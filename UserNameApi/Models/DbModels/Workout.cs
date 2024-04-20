namespace UserNameApi.Models.DbModels;

public class Workout : BaseModel
{
    public long DateStart { get; set; }
    public long DateEnd { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; }
}