

using BurberDinner.Application.Menus.Commands.CreateMenu;
using BurberDinner.Contracts.Menus;
using BurberDinner.Domain.Menu;
using Mapster;

namespace BurberDinner.Api.Common.Mapping;

using MenuSection = BurberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BurberDinner.Domain.MenuAggregate.Entities.MenuItem;

public class MenuMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config) {

    config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
      .Map(dest => dest.HostId, src => src.hostId)
      .Map(dest => dest, src => src.request);

    config.NewConfig<Menu, MenuResponse>()
      .Map(dest => dest.Id, src => src.Id.Value)
      .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating: null)
      .Map(dest => dest.HostId, src => src.HostId.Value)
      .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinner => dinner.Value))
      .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(mR => mR.Value));

    config.NewConfig<MenuSection, MenuSectionResponse>()
      .Map(dest => dest.Id, src => src.Id.Value);

    config.NewConfig<MenuItem, MenuItemResponse>()
      .Map(dest => dest.Id, src => src.Id.Value);
  }
}
