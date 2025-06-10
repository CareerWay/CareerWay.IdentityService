using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CareerWay.IdentityService.Domain.Entities;

namespace CareerWay.IdentityService.Infrastructure.Data.Contexts;

public class IdentityContext :
    IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public DbSet<Admin> Admins => Set<Admin>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<JobSeeker> JobSeekers => Set<JobSeeker>();

    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
