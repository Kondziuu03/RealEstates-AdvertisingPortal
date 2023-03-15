using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstates.Application.Common.Interfaces;
using RealEstates.Domain.Entities;
using RealEstates.Infrastructure.Identity;
using RealEstates.Infrastructure.Persistence;
using RealEstates.Infrastructure.Services;

namespace RealEstates.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbContext,ApplicationDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password = new PasswordOptions
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireNonAlphanumeric = true
            };
        })
        .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
        .AddRoleManager<RoleManager<IdentityRole>>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();

        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddSingleton<IEmail, Email>();
        services.AddSingleton<IAppSettingsService, AppSettingsService>();
        services.AddHttpContextAccessor();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IFileManagerService, FileManagerService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder,
        IApplicationDbContext context,
        IAppSettingsService appSettingsService,
        IEmail email)
    {
        appSettingsService.Update(context).GetAwaiter().GetResult();
        email.Update(appSettingsService).GetAwaiter().GetResult();

        return builder;
    }
}