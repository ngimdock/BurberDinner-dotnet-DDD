using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.MenuAggregate.ValueObjects;

namespace BurberDinner.Domain.MenuAggregate.Entities;
public sealed class MenuItem : Entity<MenuItemId>
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  private MenuItem(
    MenuItemId menuSectionId,
    string name,
    string description) : base(menuSectionId)
  {
    Name = name;
    Description = description;
  }

  public static MenuItem Create(
    string name,
    string description) {

    MenuItemId newMenuItemId = MenuItemId.CreateUnique();

    return new MenuItem(
      newMenuItemId,
      name,
      description);
  }
}