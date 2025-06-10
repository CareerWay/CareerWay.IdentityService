using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerWay.IdentityService.Infrastructure.Data.Configurations;

public class JobSeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
{
    public void Configure(EntityTypeBuilder<JobSeeker> builder)
    {
        builder.ToTable("JobSeekers", "Identity");
        builder.Property(p => p.FirstName).HasMaxLength(JobSeekerConsts.MaxFirstNameLength).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(JobSeekerConsts.MaxFirstNameLength).IsRequired();
        builder.HasOne(o => o.User).WithOne().HasForeignKey<JobSeeker>(o => o.Id).OnDelete(DeleteBehavior.NoAction);
    }
}