using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Queries.Login;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BurberDinner.Application;

public static class DependencyInjection {

  public static IServiceCollection AddApplication(this IServiceCollection services) {
    // services.AddMediatR(typeof(DependencyInjection).Assembly);

    services.AddScoped<RegisterCommandHandler, RegisterCommandHandler>();
    services.AddScoped<LoginQueryHandler, LoginQueryHandler>();

    return services;
  }
}
