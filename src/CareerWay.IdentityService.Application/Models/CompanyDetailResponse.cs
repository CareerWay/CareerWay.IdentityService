namespace CareerWay.IdentityService.Application.Models;

public class CompanyDetailResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string Landline { get; set; } = default!;

    public string? City { get; set; }

    public string ProfilePhoto { get; set; } = default!;

    public string? WebSite { get; set; }

    public string? Instragram { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Linkedin { get; set; }

    public short? EstablishmentYear { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }
}
