using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.MenuAggregate.ValueObjects;

namespace BurberDinner.Domain.MenuAggregate.Entities;
public sealed class MenuSection : Entity<MenuSectionId>
{
  public string Name { get; }
  public string Description { get; }

  private readonly List<MenuItem> _items = new();
  public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
  private MenuSection(
    MenuSectionId menuItemId,
    string name,
    string description,
    List<MenuItem> menuItems) 
    : base(menuItemId)
  {
    Name = name;
    Description = description;
    _items = menuItems;
  }
  public static MenuSection Create(
    string name,
    string description,
    List<MenuItem>? menuItems) {

    return new MenuSection(
      MenuSectionId.CreateUnique(),
      name,
      description,
      menuItems is not null ? menuItems: new());
  }

  public void AddItem(MenuItem menuItem) {
    _items.Add(menuItem);
  }
}
