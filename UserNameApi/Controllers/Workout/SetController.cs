using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("api/workout/[controller]/[action]")]
public class SetController : ControllerBase
{
    private readonly WorkoutSetService _service;
    public SetController(WorkoutSetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddSet(double weight, int reps, long workoutSessionId)
    {
        var result = await _service.AddSetAsync(weight, reps, workoutSessionId);

        return Ok(result);
    }
}