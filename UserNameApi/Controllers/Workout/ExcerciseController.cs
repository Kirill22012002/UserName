using UserNameApi.Services;

namespace UserNameApi.Controllers.Workout;

[ApiController]
[Route("api/workout/[controller]/[action]")]
public class ExcerciseController : ControllerBase
{
    private readonly WorkoutExcerciseService _service;
    public ExcerciseController(WorkoutExcerciseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllExcercisesAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] long id)
    {
        var result = await _service.GetExcerciseByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create([FromQuery] string name, [FromQuery] string description)
    {
        var result = await _service.AddExcerciseAsync(name, description);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ChangeName([FromQuery] long id, [FromQuery] string newName)
    {
        var result = await _service.ChangeExcerciseNameAsync(id, newName);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ChangeDescription([FromQuery] long id, [FromQuery] string newDescription)
    {
        var result = await _service.ChangeExcerciseDescripionAsync(id, newDescription);
        return Ok(result);
    }
}
