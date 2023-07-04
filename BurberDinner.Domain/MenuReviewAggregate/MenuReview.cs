using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.DinnerAggregate.Entities;
using BurberDinner.Domain.GuestAggregate.ValueObjects;
using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.MenuAggregate.ValueObjects;
using BurberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BurberDinner.Domain.MenuReviewAggregate;
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
  public Rating Rating { get; private set; }
  public string Comment { get; private set; }
  public HostId HostId { get; private set; }
  public MenuId MenuId { get; private set; }
  public GuestId GuestId { get; private set; }
  public DinnerId DinnerId { get; private set; }
  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }


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
    Rating rating,
    string comment,
    HostId hostId,
    MenuId menuId,
    GuestId guestId,
    DinnerId dinnerId) {

    return new MenuReview(
      MenuReviewId.CreateUnique(),
      rating,
      comment,
      hostId,
      menuId,
      guestId,
      dinnerId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}