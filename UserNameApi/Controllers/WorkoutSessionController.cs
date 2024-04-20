using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkoutSessionController : ControllerBase
{
    private readonly //WorkoutSetService _service;
    public WorkoutSessionController(//WorkoutSetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddNewSession(long startDate)
    {


        var result = await //_service.AddSetAsync(weight, reps);

        return Ok(result);
    }
}