using Newtonsoft.Json;

namespace UserNameApi.Models.ViewModels;

public class WorkoutExcerciseViewModel
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
}