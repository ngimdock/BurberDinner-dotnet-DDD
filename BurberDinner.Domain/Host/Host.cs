using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.Dinners.ValueObjects;
using BurberDinner.Domain.Host.ValueObjects;
using BurberDinner.Domain.Menu.ValueObjects;
using BurberDinner.Domain.User.ValueObjects;

namespace BurberDinner.Domain.Host;
public sealed class Host: AggregateRoot<HostId> {

  private readonly List<MenuId> _menuIds = new();
  private readonly List<DinnerId> _dinnerIds = new();
  public string FirstName { get; }
  public string LastName { get; }
  public string ProfileImage { get; }
  public AverageRating AverageRating { get; }
  public UserId UserId { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
  public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

  private  Host(
    HostId hostId,
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(hostId)
  {
    FirstName = firstName;
    LastName = lastName;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Host Create(
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId){

      return new Host(
        HostId.CreateUnique(),
        firstName,
        lastName,
        profileImage,
        averageRating,
        userId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
}
