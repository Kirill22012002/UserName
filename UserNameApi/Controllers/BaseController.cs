using Microsoft.AspNetCore.Identity;
using UserNameApi.Models.DbModels;

namespace UserNameApi.Controllers;

public class BaseController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public BaseController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    protected async Task<ApplicationUser> GetCurrentUserAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        return user;
    }
}
