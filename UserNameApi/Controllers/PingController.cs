namespace UserNameApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public string Ping()
    {
        return "pong";
    }
}