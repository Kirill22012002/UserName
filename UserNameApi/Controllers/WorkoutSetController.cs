using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkoutSetController : ControllerBase
{
    private readonly WorkoutSetService _service;
    public WorkoutSetController(WorkoutSetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddSet(double weight, int reps)
    {
        var result = await _service.AddSetAsync(weight, reps);

        return Ok(result);
    }
}