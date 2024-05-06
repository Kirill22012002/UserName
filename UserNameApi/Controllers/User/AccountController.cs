using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using UserNameApi.Models.DbModels;
using UserNameApi.Models.ViewModels;

namespace UserNameApi.Controllers.User;

[ApiController]
[Route("api/user/[controller]/[action]")]
public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token = token });
            }
        }
        return BadRequest("Invalid data");
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            var token = GenerateJwtToken(user);
            return Ok(new { token = token });
        }
        return BadRequest("Invalid login attempt");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await _userManager.GetUserAsync(User);
        return Ok(user);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> SignOutUser()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }


    private string GenerateJwtToken(ApplicationUser user)
    {
        var key = new byte[64];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }

        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken("JwtIssuer",
          "JwtIssuer",
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}