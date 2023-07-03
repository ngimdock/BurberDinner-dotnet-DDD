



using BurberDinner.Application.Menus.Commands;
using BurberDinner.Contracts.Menus;
using Mapster;

public class MenuMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {

    config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
      .Map(dest => dest.HostId, src => src.hostId)
      .Map(dest => dest, src => src.request);
      
    throw new NotImplementedException();
  }
}