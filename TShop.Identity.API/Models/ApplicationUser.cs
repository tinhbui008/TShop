using Microsoft.AspNetCore.Identity;

namespace TShop.Identity.API.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}