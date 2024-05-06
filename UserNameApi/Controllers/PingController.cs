using Microsoft.AspNetCore.Identity;
using UserNameApi.Models.DbModels;

namespace UserNameApi.Controllers;

[ApiController]
[Route("[action]")]
public class PingController : BaseController
{
    public PingController(UserManager<ApplicationUser> userManager) : base(userManager) { }

    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(1);
    }

    [HttpGet]
    public IActionResult AuthorizedPing()
    {
        return Ok(1);
    }
}
