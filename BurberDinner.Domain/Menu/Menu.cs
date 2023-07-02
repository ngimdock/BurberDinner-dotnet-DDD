using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Menu.Entities;
using BurberDinner.Domain.Menu.ValueObjects;

namespace BurberDinner.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId>
{

  public string Name { get; }
  public string Description { get; }
  public float AverageRating { get; }

  private readonly List<MenuSection> _sections = new();

  public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
  private Menu(
    MenuId menuId,
    string name,
    string description) : base(menuId)
  {
    Name = name;
    Description = description;
  }

  public static Menu Create(
    string name,
    string description) {

    MenuId newMenuId = MenuId.CreateUnique();

    return new Menu(
      newMenuId,
      name,
      description);
  }
}
