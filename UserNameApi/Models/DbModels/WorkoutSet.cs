namespace UserNameApi.Models.DbModels;

public class WorkoutSet : IEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public double Weight { get; set; }
    public int Reps { get; set; }
}