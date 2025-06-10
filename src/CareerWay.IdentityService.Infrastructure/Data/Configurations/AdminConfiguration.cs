using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerWay.IdentityService.Infrastructure.Data.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins", "Identity");
        builder.Property(p => p.FirstName).HasMaxLength(AdminConsts.MaxFirstNameLength).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(AdminConsts.MaxLastNameLength).IsRequired();
        builder.HasOne(o => o.User).WithOne().HasForeignKey<Admin>(o => o.Id).OnDelete(DeleteBehavior.NoAction);
    }
}
