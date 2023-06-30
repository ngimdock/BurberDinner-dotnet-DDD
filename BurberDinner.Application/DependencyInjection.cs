using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Common;
using BurberDinner.Application.Authentication.Queries.Login;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BurberDinner.Application;

public static class DependencyInjection {

  public static IServiceCollection AddApplication(this IServiceCollection services) {
    // services.AddMediatR(typeof(DependencyInjection).Assembly);

    services.AddScoped<RegisterCommandHandler, RegisterCommandHandler>();
    services.AddScoped<LoginQueryHandler, LoginQueryHandler>();

    services.AddScoped<
      IPipelineBehavior<RegisterCommand, AuthenticationResult>,
      ValidateRegisterCommandBehavior
    >();
    
    services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

    // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    // install package FluentValidation.AspNetCore pour importer AddValidatorsFromAssembly

    return services;
  }
}
