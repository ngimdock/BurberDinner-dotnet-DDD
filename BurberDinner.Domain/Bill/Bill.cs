using BurberDinner.Domain.Bill.ValueObjects;
using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Common.ValueObjects;
using BurberDinner.Domain.Dinners.ValueObjects;
using BurberDinner.Domain.Guest.ValueObjects;
using BurberDinner.Domain.Host.ValueObjects;

namespace BurberDinner.Domain.Bill;


public sealed class Bill : AggregateRoot<BillId>
{
  public DinnerId DinnerId { get; }
  public GuestId GuestId { get; }
  public HostId HostId { get; }
  public Price Price { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
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