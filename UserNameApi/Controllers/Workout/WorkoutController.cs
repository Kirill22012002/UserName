using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using UserNameApi.Models.DbModels;
using UserNameApi.Services;

namespace UserNameApi.Controllers.Workout;

[ApiController]
[Route("api/workout/[action]")]
public class WorkoutController : BaseController
{
    private readonly WorkoutService _service;
    public WorkoutController(
        UserManager<ApplicationUser> userManager, 
        WorkoutService service) : base(userManager)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> StartNewWorkout()
    {
        var user = await GetCurrentUserAsync();
        var result = await _service.StartNewWorkoutAsync(user);
        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> EndWorkout()
    {
        var user = await GetCurrentUserAsync();
        await _service.EndWorkoutAsync(user);
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