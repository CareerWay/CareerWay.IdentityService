namespace CareerWay.IdentityService.Domain.Entities;

public class Admin : User
{
    //public virtual Guid UserId { get; set; } = default!;

    public virtual string FirstName { get; set; } = default!;

    public virtual string LastName { get; set; } = default!;

    public virtual User User { get; set; } = default!;
}
