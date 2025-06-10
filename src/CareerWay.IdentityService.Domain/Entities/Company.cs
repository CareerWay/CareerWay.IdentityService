using CareerWay.IdentityService.Domain.Enums;

namespace CareerWay.IdentityService.Domain.Entities;

public class Company : User
{
    public virtual string Title { get; set; } = default!;

    public virtual string FirstName { get; set; } = default!;

    public virtual string LastName { get; set; } = default!;

    public virtual string Landline { get; set; } = default!;

    public virtual int? CityId { get; set; }

    public virtual string? ProfilePhoto { get; set; }

    public virtual string? WebSite { get; set; }

    public virtual string? Instragram { get; set; }

    public virtual string? Facebook { get; set; }

    public virtual string? Twitter { get; set; }

    public virtual string? Linkedin { get; set; }

    public virtual short? EstablishmentYear { get; set; }

    public virtual string? Description { get; set; }

    public virtual string? Address { get; set; }

    public virtual CompanyStatus Status { get; set; }

    public virtual City City { get; set; } = default!;

    public virtual User User { get; set; } = default!;
}
