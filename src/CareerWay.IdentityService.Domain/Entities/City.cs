using CareerWay.Shared.Domain.Entities;

namespace CareerWay.IdentityService.Domain.Entities;

public class City : IEntity
{
    public virtual int Id { get; set; }

    public virtual string Name { get; set; } = default!;
}
