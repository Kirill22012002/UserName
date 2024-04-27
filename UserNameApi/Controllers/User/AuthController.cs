using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserNameApi.Models.Models;
using UserNameApi.Services;

namespace UserNameApi.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    /*[HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
        if (_userService.IsUsernameTaken(model.UserName))
            return Conflict("Username is already taken.");

        _userService.Register(model);

        var authenticatedUser = _userService.Authenticate(model.UserName, model.Password);

        if (authenticatedUser == null)
            return Unauthorized();

        var tokenString = GenerateJWTToken(authenticatedUser);
        return Ok(new { Token = tokenString });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        var authenticatedUser = _userService.Authenticate(user.UserName, user.Password);

        if (authenticatedUser == null)
            return Unauthorized();

        var tokenString = GenerateJWTToken(authenticatedUser);
        return Ok(new { Token = tokenString });
    }*/

    /*private string GenerateJWTToken(Models.DbModels.User user)
    {
        var credentials = new SigningCredentials("_securityKey", SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30), // Example: Token expires in 30 minutes
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }*/
}