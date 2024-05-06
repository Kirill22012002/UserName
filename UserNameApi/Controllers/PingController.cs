namespace UserNameApi.Controllers;

[ApiController]
[Route("[action]")]
public class PingController : ControllerBase
{
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