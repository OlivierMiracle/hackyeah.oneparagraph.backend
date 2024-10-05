using Microsoft.AspNetCore.Identity;
using OneParagraph.Shared.Enums;

namespace OneParagraph.Shared.Identity;

public sealed class User : IdentityUser
{
    public Industry FollowedIndustries { get; set; }
}