using Microsoft.AspNetCore.Identity;

namespace CareerWay.IdentityService.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public Role()
        : base()
    {
    }

    public Role(string roleName)
        : base(roleName)
    {
    }
}
