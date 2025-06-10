using CareerWay.Shared.Security.Tokens;

namespace CareerWay.IdentityService.Application.Models;

public class CreateJobSeekerResponse
{
    public AccessToken AccessToken { get; set; } = default!;
}
