
namespace BurberDinner.Api;

public static class DependencyInjection {

  public static IServiceCollection AddPresentation(this IServiceCollection services) {
    
    services.AddMappings();

    return services;
  }
}