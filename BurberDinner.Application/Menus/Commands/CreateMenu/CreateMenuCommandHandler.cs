
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Application.Menus.Commands;
using BurberDinner.Domain.Menu;
using MediatR;

namespace BurberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler
{
  private readonly IMenuRepository _menuRepository;
  public CreateMenuCommandHandler(IMenuRepository menuRepository) {
    _menuRepository = menuRepository;
  }

  public Task<Menu> Handle(CreateMenuCommand command)
  {

    // create menu

    // persist menu

    // return menu
    return default!;
  }
}