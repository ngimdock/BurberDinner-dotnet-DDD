using BurberDinner.Domain.BillAgregate.ValueObjects;

using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.DinnerAggregate.Entities;
using BurberDinner.Domain.GuestAggregate.ValueObjects;
using BurberDinner.Domain.HostAggregate.ValueObjects;

namespace BurberDinner.Domain.BillAgregate;
public sealed class Bill : AggregateRoot<BillId>
{
  public DinnerId DinnerId { get; private set; }
  public GuestId GuestId { get; private set; }
  public HostId HostId { get; private set; }
  public Price Price { get; private set; }
  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }
  private Bill(
    BillId billId,
    DinnerId dinnerId,
    GuestId guestId,
    HostId hostId,
    Price price,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(billId)
  {
    DinnerId = dinnerId;
    GuestId = guestId;
    HostId = hostId;
    Price = price;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Bill Create(
    DinnerId dinnerId,
    GuestId guestId,
    HostId hostId,
    Price price) {

    return new Bill(
      BillId.CreateUnique(),
      dinnerId,
      guestId,
      hostId,
      price,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}