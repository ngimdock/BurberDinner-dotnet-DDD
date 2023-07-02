using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Menu.ValueObjects;

namespace BurberDinner.Domain.Menu.Entities;


public sealed class MenuItem : Entity<MenuItemId>
{
  public string Name { get; }
  public string Description { get; }
  private MenuItem(
    MenuItemId menuSectionId,
    string name,
    string description) : base(menuSectionId)
  {
    Name = name;
    Description = description;
  }

  public MenuItem Create(
    string name,
    string description) {

    MenuItemId newMenuItemId = MenuItemId.CreateUnique();

    return new MenuItem(
      newMenuItemId,
      name,
      description);
  }
}
