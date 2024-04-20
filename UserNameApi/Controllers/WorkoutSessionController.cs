using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkoutSessionController : ControllerBase
{
    private readonly WorkoutSessionService _service;
    public WorkoutSessionController(WorkoutSessionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddNewSession([FromQuery] long excerciseId)
    {
        var result = await _service.AddNewSessionAsync(excerciseId);

        return Ok(result);
    }
}