using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("api/workout/[controller]/[action]")]
public class SessionController : ControllerBase
{
    private readonly WorkoutSessionService _service;
    public SessionController(WorkoutSessionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddNewSession([FromQuery] long excerciseId, [FromQuery] long workoutId)
    {
        var result = await _service.AddNewSessionAsync(excerciseId, workoutId);

        return Ok(result);
    }
}