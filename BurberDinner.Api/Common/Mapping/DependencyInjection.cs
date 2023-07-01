using System.Reflection;


using Mapster;
using MapsterMapper;

namespace BurberDinner.Api.Common.Mapping;
public static class DependencyInjection {

  public static IServiceCollection AddMappings(this IServiceCollection services) {


    var config = TypeAdapterConfig.GlobalSettings;

    config.Scan(Assembly.GetExecutingAssembly());

    services.AddSingleton(config);
    services.AddScoped<IMapper, Mapper>();
    
    return services;
  }
}
