using Microsoft.AspNetCore.Identity;

namespace UserNameApi.Models.DbModels;

public class ApplicationUser : IdentityUser
{
    public long CurrentWorkoutId { get; set; }
    public long CurrentSessionId { get; set; }
}