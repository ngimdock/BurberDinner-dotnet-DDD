
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.Menu;
using BurberDinner.Domain.MenuAggregate.Entities;

namespace BurberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler{

  private readonly IMenuRepository _menuRepository;

  public CreateMenuCommandHandler(IMenuRepository menuRepository) {
    _menuRepository = menuRepository;
  }

  public async Task<Menu> Handle(CreateMenuCommand command)
  {
    await Task.CompletedTask;

    List<MenuSection> menuSections = command.Sections.ConvertAll(s => MenuSection.Create(
      s.Name,
      s.Description,
      s.Items.ConvertAll(item => MenuItem.Create(
        item.Name,
        item.Description))));

        
    Menu menu = Menu.Create(
      name: command.Name,
      description: command.Description,
      hostId: HostId.Create(command.HostId),
      menuSections: menuSections);
    
    _menuRepository.Add(menu);
    
    return menu;
  }
}