namespace UserNameApi.Models.DbModels;

public class WorkoutSession : IEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public WorkoutExcercise WorkoutExcercise { get; set; }
    public List<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}