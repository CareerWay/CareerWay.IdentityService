using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerWay.IdentityService.Infrastructure.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "Identity");
        builder.Property(p => p.Title).HasMaxLength(CompanyConsts.MaxTitleLength).IsRequired();
        builder.Property(p => p.FirstName).HasMaxLength(CompanyConsts.MaxFirstNameLength).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(CompanyConsts.MaxLastNameLength).IsRequired();
        builder.Property(p => p.PhoneNumber).HasMaxLength(CompanyConsts.MaxPhoneLength).IsRequired();
        builder.Property(p => p.CityId).IsRequired(false);
        builder.Property(p => p.Landline).HasMaxLength(CompanyConsts.MaxLandlineLength).IsRequired();
        builder.Property(p => p.ProfilePhoto).IsRequired(false);
        builder.Property(p => p.WebSite).HasMaxLength(CompanyConsts.MaxWebSiteLength).IsRequired(false);
        builder.Property(p => p.Instragram).HasMaxLength(CompanyConsts.MaxInstragramLength).IsRequired(false);
        builder.Property(p => p.Facebook).HasMaxLength(CompanyConsts.MaxFacebookLength).IsRequired(false);
        builder.Property(p => p.Twitter).HasMaxLength(CompanyConsts.MaxTwitterLength).IsRequired(false);
        builder.Property(p => p.Linkedin).HasMaxLength(CompanyConsts.MaxWebSiteLength).IsRequired(false);
        builder.Property(p => p.Linkedin).HasMaxLength(CompanyConsts.MaxWebSiteLength).IsRequired(false);
        builder.Property(p => p.EstablishmentYear).IsRequired(false);
        builder.Property(p => p.Description).HasMaxLength(CompanyConsts.MaxDescriptionLength).IsRequired(false);
        builder.Property(p => p.Address).HasMaxLength(CompanyConsts.MaxAddressLength).IsRequired(false);

        builder.HasOne(o => o.User).WithOne().HasForeignKey<Company>(o => o.Id).OnDelete(DeleteBehavior.NoAction);
    }
}
