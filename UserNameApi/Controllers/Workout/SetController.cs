using Microsoft.AspNetCore.Identity;
using UserNameApi.Models.DbModels;
using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("api/workout/[controller]/[action]")]
public class SetController : BaseController
{
    private readonly WorkoutSetService _service;
    public SetController(
        UserManager<ApplicationUser> userManager,
        WorkoutSetService service) : base(userManager)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> AddSet([FromQuery] double weight, [FromQuery] int reps)
    {
        var user = await GetCurrentUserAsync();
        var result = await _service.AddSetAsync(user, weight, reps);
        return Ok(result);
    }
}