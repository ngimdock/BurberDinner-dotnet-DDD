using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Menu.ValueObjects;

namespace BurberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
  public string Name { get; }
  public string Description { get; }

  private readonly List<MenuItem> _items = new();
  public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
  private MenuSection(
    MenuSectionId menuItemId,
    string name,
    string description) 
    : base(menuItemId)
  {
    Name = name;
    Description = description;
  }
  public static MenuSection Create(
    string name,
    string description) {

    MenuSectionId newMenuSectionId = MenuSectionId.CreateUnique();

    return new MenuSection(
      newMenuSectionId,
      name,
      description);
  }
}
