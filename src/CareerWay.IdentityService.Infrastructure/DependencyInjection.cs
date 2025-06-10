using CareerWay.IdentityService.Domain.Entities;
using CareerWay.IdentityService.Domain.Localization;
using CareerWay.IdentityService.Infrastructure.Consts;
using CareerWay.IdentityService.Infrastructure.Data.Contexts;
using CareerWay.Shared.Core.Guards;
using CareerWay.Shared.Localization.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Guard.Against.Null(services, nameof(services));
        Guard.Against.Null(configuration, nameof(configuration));

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseAzureSql(configuration[ConfigKeys.AzureSQL.ConnectionString]);
        });

        services.AddScoped<IdentityContextInitializer>();

        services.AddSequentialGuidGenerator();

        services.AddMachineTimeProvider();

        services.AddNewtonsoftJsonSerializer(options => { });

        services.AddCustomCorrelationId();

        services.AddDefaultIdentity<User>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
        })
        .AddDefaultTokenProviders()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<IdentityContext>();

        services.AddIdentityCore<Admin>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
        })
        .AddDefaultTokenProviders()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<IdentityContext>();

        services.AddIdentityCore<Company>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
        })
        .AddDefaultTokenProviders()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<IdentityContext>();

        services.AddIdentityCore<JobSeeker>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
        })
        .AddDefaultTokenProviders()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<IdentityContext>();

        services.AddJsonStringLocalizer();

        services.Configure<RequestLocalizationOptions>(options =>
        {
            CultureInfo[] cultures =
            [
                new("tr-TR")
            ];
            options.DefaultRequestCulture = new RequestCulture("tr-TR");
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
            options.RequestCultureProviders = [new AcceptLanguageHeaderRequestCultureProvider()];
        });

        services.Configure<JsonLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IdentityServiceResource>("/Localization/IdentityService", "IdentityServiceResource", "tr-TR");
        });

        services.AddSecurity(options =>
        {
            options.Issuer = configuration.GetValue<string>("AccessTokenOptions:Issuer")!;
            options.Audience = configuration.GetValue<string>("AccessTokenOptions:Audience")!;
            options.Expiration = configuration.GetValue<int?>("AccessTokenOptions:Expiration") ?? 360;
            options.SecurityKey = configuration.GetValue<string>("AccessTokenSecurityKey")!;
        });

        //services.AddEventBus(options =>
        //{
        //    options.ProjectName = "CareerWay";
        //    options.ServiceName = "IdentityService";
        //    options.UseKafka(services, kafkaOptions =>
        //    {
        //        kafkaOptions.ProducerConfig.BootstrapServers = "localhost:9092"; //TODO: Read from appsettings.json
        //        kafkaOptions.ConsumerConfig.BootstrapServers = "localhost:9092";
        //        kafkaOptions.ConsumerConfig.GroupId = "CareerWay.IdentityService.Group";
        //        kafkaOptions.ConsumerConfig.AutoOffsetReset = AutoOffsetReset.Earliest;
        //        kafkaOptions.ConsumerConfig.ClientId = "CareerWay.IdentityService";
        //        kafkaOptions.ConsumerConfig.AllowAutoCreateTopics = true;
        //        kafkaOptions.AdminClientConfig.AllowAutoCreateTopics = true;
        //        kafkaOptions.AdminClientConfig.BootstrapServers = "localhost:9092";
        //    });
        //});

        return services;
    }
}
