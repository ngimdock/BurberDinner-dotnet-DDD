using BuberDinner.Contracts.Authentication;
using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Common;
using BurberDinner.Application.Authentication.Queries.Login;
using Mapster;

namespace BurberDinner.Api.Common.Mapping;



public class AuthenticationMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {

    config.NewConfig<RegisterRequest, RegisterCommand>();

    config.NewConfig<LoginRequest, LoginQuery>();

    config.NewConfig<AuthenticationResult, AuthenticationResponse>()
      .Map(dest => dest, src => src.user);
  }
}
