using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.DinnerAggregate.Entities;
using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.MenuAggregate.Entities;
using BurberDinner.Domain.MenuAggregate.ValueObjects;
using BurberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BurberDinner.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId>
{

  private readonly List<MenuSection> _sections = new();
  private readonly List<DinnerId> _dinnerIds = new();
  private readonly List<MenuReviewId> _menuReviewIds = new();
  public string Name { get; private set; }
  public string Description { get; private set; }
  public AverageRating AverageRating { get; private set; }
  public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
  public HostId HostId { get; private set; }

  public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
  public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }
  private Menu(
    MenuId menuId,
    string name,
    string description,
    AverageRating averageRating,
    HostId hostId,
    List<MenuSection> sections,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(menuId)
  {
    Name = name;
    Description = description;
    AverageRating = averageRating;
    HostId = hostId;
    _sections = sections;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Menu Create(
    string name,
    string description,
    HostId hostId,
    List<MenuSection>? menuSections
    ) {

    return new Menu(
      MenuId.CreateUnique(),
      name,
      description,
      AverageRating.Create(),
      hostId,
      menuSections is not null ? menuSections : new(),
      DateTime.UtcNow,
      DateTime.UtcNow);
  }

  public void AddSection(MenuSection section) {
    _sections.Add(section);
  }
}