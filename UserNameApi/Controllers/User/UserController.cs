using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UserNameApi.Services;

namespace UserNameApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetUser([FromQuery] long id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out long userId))
            return Unauthorized();

        if (userId != id)
            return Forbid();

        var user = _userService.GetById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
}