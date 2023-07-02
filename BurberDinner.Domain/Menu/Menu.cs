using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.Dinners.ValueObjects;
using BurberDinner.Domain.Host.ValueObjects;
using BurberDinner.Domain.Menu.Entities;
using BurberDinner.Domain.Menu.ValueObjects;
using BurberDinner.Domain.MenuReview.ValueObjects;

namespace BurberDinner.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId>
{

  private readonly List<MenuSection> _sections = new();
  private readonly List<DinnerId> _dinnerIds = new();
  private readonly List<MenuReviewId> _menuReviewIds = new();
  public string Name { get; }
  public string Description { get; }
  public AverageRating AverageRating { get; }
  public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
  public HostId HostId { get; }

  public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
  public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Menu(
    MenuId menuId,
    string name,
    string description,
    HostId hostId,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(menuId)
  {
    Name = name;
    Description = description;
    HostId = hostId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Menu Create(
    string name,
    string description, HostId hostId) {

    return new Menu(
      MenuId.CreateUnique(),
      name,
      description,
      hostId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}
