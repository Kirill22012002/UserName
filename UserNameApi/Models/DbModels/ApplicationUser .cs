using Microsoft.AspNetCore.Identity;

namespace UserNameApi.Models.DbModels;

public class ApplicationUser : IdentityUser
{
    public string CurrentWorkoutId { get; set; }
    public string CurrentSessionId { get; set; }
}
