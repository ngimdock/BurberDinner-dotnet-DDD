
using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.services;
using BurberDinner.Infrastructure.Authentication;
using BurberDinner.Infrastructure.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BurberDinner.Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.Options;
using BurberDinner.Infrastructure.Persistence;
using BurberDinner.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BurberDinner.Infrastructure;

public static class DependencyInjection {

  public static IServiceCollection AddInfrastructure(
      this IServiceCollection services, 
      ConfigurationManager configuration) {

    services.AddAuth(configuration)
            .AddPersistence();


    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    return services;
  }

    public static IServiceCollection AddPersistence(
      this IServiceCollection services) {

      services.AddDbContext<BuberDinnerDbContext>(options => 
        options.UseSqlServer(""));
      services.AddSingleton<IUserRepository, UserRepository>();
      services.AddSingleton<IMenuRepository, MenuRepository>();
      return services;
    }

   public static IServiceCollection AddAuth(
      this IServiceCollection services, 
      ConfigurationManager configuration) 
  {

    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.Servicename, jwtSettings);

    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    
    services.AddSingleton(Options.Create(jwtSettings));


    // services.AddAuthentication(defaultScheme: "Bearer")
    //   .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidation()
    //   {
    //     ValidateIssuer = true,
    //     ValidateAudience = true,
    //     ValidateLiveTime = true,
    //     ValidateIssuerSingningKey = true,
    //     ValidIssuer = jwtSettings.Issuer,
    //     ValidAudience = jwtSettings.Audience,
    //     IsuerSingingKey = new SymmetricSecurityKey(
    //       Encoding.UTF8.GetBytes(jwtSettings.Secret)
    //     )
    //   });

    return services;
  }
}
