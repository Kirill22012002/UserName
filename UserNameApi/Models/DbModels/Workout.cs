namespace UserNameApi.Models.DbModels;

public class Workout : IEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public long StartDate { get; set; }
    public long EndDate { get; set; }
    public string UserId { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}