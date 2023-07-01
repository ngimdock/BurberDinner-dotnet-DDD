using System.Text;

using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.services;
using BurberDinner.Infrastructure.Authentication;
using BurberDinner.Infrastructure.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BurberDinner.Application.Common.Interfaces.Persistence;


namespace BurberDinner.Infrastructure;

public static class DependencyInjection {

  public static IServiceCollection AddInfrastructure(
      this IServiceCollection services, 
      ConfigurationManager configuration) {

    services.AddAuth(configuration);
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    services.AddSingleton<IUserRepository, UserRepository>();
    return services;
  }

   public static IServiceCollection AddAuth(
      this IServiceCollection services, 
      ConfigurationManager configuration) 
  {

    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.Servicename, jwtSettings);

    services.AddSingleton(Options.Create(jwtSettings));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


    services.AddAuthentication(defaultScheme: "Bearer")
      .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidation()
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLiveTime = true,
        ValidateIssuerSingningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IsuerSingingKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(jwtSettings.Secret)
        )
      });

    return services;
  }
}
