using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.MenuAggregate.ValueObjects;

namespace BurberDinner.Domain.DinnerAggregate.Entities;
public sealed class Dinner: AggregateRoot<DinnerId> {

  private List<Reservation> _reservations = new();
  public string Name { get; }
  public string Description { get; }
  public DateTime StartDateTime { get; }
  public DateTime EndDateTime { get; }
  public DateTime StartedDateTime { get; }
  public DateTime EndedDateTime { get; }
  public DinnerStatus Status { get; }
  public bool IsPublic { get; }
  public int MaxGuests { get; }
  public Price Price { get; }
  public HostId HostId { get; }
  public MenuId MenuId { get; }
  public string ImageUrl { get; }

  public Location Location { get; }
  public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Dinner(
    DinnerId dinnerId,
    string name,
    string description,
    DateTime startedDateTime,
    DateTime endedDateTime,
    DinnerStatus status,
    bool isPublic,
    int maxGuests,
    Price price,
    HostId hostId,
    MenuId menuId,
    string imageUrl,
    Location location,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(dinnerId)
  {
    Name = name;
    Description = description;
    StartDateTime = startedDateTime;
    EndDateTime = endedDateTime;
    Status = status;
    IsPublic = isPublic;
    MaxGuests = maxGuests;
    Price = price;
    HostId = hostId;
    MenuId = menuId;
    ImageUrl = imageUrl;
    Location = location;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Dinner Create(
    string name,
    string description,
    DateTime startedDateTime,
    DateTime endedDateTime,
    DinnerStatus status,
    bool isPublic,
    int maxGuests,
    Price price,
    HostId hostId,
    MenuId menuId,
    string imageUrl,
    Location location) {

      return new Dinner(
        DinnerId.CreateUnique(),
        name,
        description,
        startedDateTime,
        endedDateTime,
        status,
        isPublic,
        maxGuests,
        price,
        hostId,
        menuId,
        imageUrl,
        location,
        DateTime.UtcNow,
        DateTime.UtcNow
      );
    }
}
