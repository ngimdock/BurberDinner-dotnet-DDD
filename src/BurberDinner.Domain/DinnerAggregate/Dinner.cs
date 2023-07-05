using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.MenuAggregate.ValueObjects;

namespace BurberDinner.Domain.DinnerAggregate.Entities;
public sealed class Dinner: AggregateRoot<DinnerId> {

  private List<Reservation> _reservations = new();
  public string Name { get; private set; }
  public string Description { get; private set; }
  public DateTime StartDateTime { get; private set; }
  public DateTime EndDateTime { get; private set; }
  public DateTime StartedDateTime { get; private set; }
  public DateTime EndedDateTime { get; private set; }
  public DinnerStatus Status { get; private set; }
  public bool IsPublic { get; private set; }
  public int MaxGuests { get; private set; }
  public Price Price { get; private set; }
  public HostId HostId { get; private set; }
  public MenuId MenuId { get; private set; }
  public string ImageUrl { get; private set; }

  public Location Location { get; private set; }
  public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }
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
