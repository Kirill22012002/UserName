namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(1);
    }
}