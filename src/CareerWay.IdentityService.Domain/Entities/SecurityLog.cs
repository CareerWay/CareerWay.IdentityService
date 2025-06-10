namespace CareerWay.IdentityService.Domain.Entities;

public class SecurityLog
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Action { get; set; } = default!;

    public DateTime CreationDate { get; set; }

    public User User { get; set; } = default!;
}
