
using BurberDinner.Domain.Menu;
using MediatR;

namespace BurberDinner.Application.Menus.Commands;

public record CreateMenuCommand(
  string HostId,
  string Name,
  string Description,
  List<MenuSectionCommand> Sections
): IRequest<Menu>;

public record MenuSectionCommand(
  string Name,
  string Description,
  List<MenuItemCommand> Items
);

public record MenuItemCommand(
  string Name,
  string Description
);