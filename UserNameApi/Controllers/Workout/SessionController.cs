using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using UserNameApi.Models.DbModels;
using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("api/workout/[controller]/[action]")]
public class SessionController : BaseController
{
    private readonly WorkoutSessionService _service;
    public SessionController(
        UserManager<ApplicationUser> userManager,
        WorkoutSessionService service) : base(userManager)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> AddNewSession([FromQuery] long excerciseId)
    {
        var user = await GetCurrentUserAsync();
        var result = await _service.AddNewSessionAsync(user, excerciseId);
        return Ok(result);
    }
}