
using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.services;
using BurberDinner.Infrastructure.Authentication;
using BurberDinner.Infrastructure.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BurberDinner.Application.Common.Interfaces.Persistence;


namespace BurberDinner.Infrastructure;

public static class DependencyInjection {

  public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration) {

    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Servicename));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    services.AddSingleton<IUserRepository, UserRepository>();
    return services;
  }
}
