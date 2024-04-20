using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkoutController : ControllerBase
{
    private readonly WorkoutService _service;
    public WorkoutController(WorkoutService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> StartNewWorkout()
    {
        var result = await _service.StartNewWorkoutAsync();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddNewSessionToWorkout([FromQuery] long sessionId, [FromQuery] long workoutId)
    {
        await _service.AddNewSessionToWorkoutAsync(sessionId, workoutId);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> EndNewWorkout([FromQuery] long workoutId)
    {
        await _service.EndWorkoutAsync(workoutId);

        return Ok();
    }

    [HttpGet]
    public IActionResult GetFullWorkoutInfo([FromQuery] long workoutId)
    {
        var result = _service.GetFullWorkoutInfo(workoutId);

        return Ok(result);
    }
}