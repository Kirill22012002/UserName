using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkoutExcerciseController : ControllerBase
{
    private readonly WorkoutExcerciseService _service;
    public WorkoutExcerciseController(WorkoutExcerciseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExcercises()
    {
        var result = await _service.GetAllExcercisesAsync();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetExcerciseById([FromQuery] long id)
    {
        var result = await _service.GetExcerciseByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddExcercise([FromQuery] string name, [FromQuery] string description)
    {
        var result = await _service.AddExcerciseAsync(name, description);
        return Ok(result);
    }
}