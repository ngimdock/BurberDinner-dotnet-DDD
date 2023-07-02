using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.Dinners.ValueObjects;
using BurberDinner.Domain.Guest.ValueObjects;
using BurberDinner.Domain.Host.ValueObjects;
using BurberDinner.Domain.Menu.ValueObjects;
using BurberDinner.Domain.MenuReview.ValueObjects;

namespace BurberDinner.Domain.MenuReview;


public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
  public Rating Rating { get; }
  public string Comment { get; }
  public HostId HostId { get; }
  public MenuId MenuId { get; }
  public GuestId GuestId { get; }
  public DinnerId DinnerId { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }


  private MenuReview(
    MenuReviewId menuReviewId,
    Rating rating,
    string comment,
    HostId hostId,
    MenuId menuId,
    GuestId guestId,
    DinnerId dinnerId,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(menuReviewId)
  {
    Rating = rating;
    Comment = comment;
    HostId = hostId;
    MenuId = menuId;
    GuestId = guestId;
    DinnerId = dinnerId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static MenuReview Create(
    float ratingValue,
    string comment,
    HostId hostId,
    MenuId menuId,
    GuestId guestId,
    DinnerId dinnerId) {

    return new MenuReview(
      MenuReviewId.CreateUnique(),
      Rating.Create(ratingValue),
      comment,
      hostId,
      menuId,
      guestId,
      dinnerId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}
