namespace UserNameApi.Models.DbModels;

public class WorkoutSession : BaseModel
{
    public WorkoutExcercise WorkoutExcercise { get; set; }
    public List<WorkoutSet> WorkoutSet { get; set; }
}