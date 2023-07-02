using BurberDinner.Domain.BillAgregate.ValueObjects;
using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.DinnerAggregate.Entities;
using BurberDinner.Domain.GuestAggregate.ValueObjects;
using BurberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BurberDinner.Domain.UserAggregate.ValueObjects;

namespace BurberDinner.Domain.GuestAggregate;
public sealed class Guest : AggregateRoot<GuestId>
{
  private List<DinnerId> _upcommingDinnerIds = new();
  private List<DinnerId> _pastDinnerIds = new();
  private List<DinnerId> _pendingDinnerIds = new();
  private List<BillId> _billIds = new();
  private List<MenuReviewId> _menuReviewIds = new();
  private List<Rating> _ratings = new();
  public string FirstName { get; }
  public string LastName { get; }
  public string ProfileImage { get; }
  public AverageRating AverageRating { get; }
  public UserId UserId { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }

  private IReadOnlyList<DinnerId> UpcommingDinnerIds => _upcommingDinnerIds.AsReadOnly();
  private IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
  private IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
  private IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
  private IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
  private IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
  
  private Guest(
    GuestId guestId,
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId, 
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(guestId)
  {
    FirstName = firstName;
    LastName = lastName;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Guest Create(
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId){
      return new Guest(
        GuestId.CreateUnique(),
        firstName,
        lastName,
        profileImage,
        averageRating,
        userId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
}
