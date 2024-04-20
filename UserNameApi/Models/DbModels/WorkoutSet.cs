namespace UserNameApi.Models.DbModels;

public class WorkoutSet : BaseModel
{
    public double Weight { get; set; }
    public int Reps { get; set; }
}