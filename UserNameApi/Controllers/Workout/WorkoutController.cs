using UserNameApi.Services;

namespace UserNameApi.Controllers.Workout;

[ApiController]
[Route("api/workout/[action]")]
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
    public async Task<IActionResult> EndWorkout([FromQuery] long workoutId)
    {
        await _service.EndWorkoutAsync(workoutId);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> RemoveWorkout([FromQuery] long workoutId)
    {
        await _service.RemoveWorkoutAsync(workoutId);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetFullWorkoutInfo([FromQuery] long workoutId)
    {
        var result = _service.GetFullWorkoutInfo(workoutId);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAllFullWorkoutInfo()
    {
        var result = _service.GetAllFullWorkoutInfo();
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAllWorkoutsByExcerciseId([FromQuery] long excerciseId)
    {
        var result = _service.GetAllWorkoutsByExcerciseId(excerciseId);
        return Ok(result);
    }
}