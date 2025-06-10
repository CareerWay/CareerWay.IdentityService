using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Mappers;
using CareerWay.IdentityService.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ICompanyMapper, CompanyMapper>(); 
        services.AddSingleton<IJobSeekerMapper, JobSeekerMapper>();
        
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IJobSeekerService, JobSeekerService>();
        services.AddScoped<ILoginService, LoginService>();

        return services;
    }
}
