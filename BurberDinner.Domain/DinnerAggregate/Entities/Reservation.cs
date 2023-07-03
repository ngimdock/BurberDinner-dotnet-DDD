using BurberDinner.Domain.BillAgregate.ValueObjects;
using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.GuestAggregate.ValueObjects;

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : AggregateRoot<ReservationId>
{
  public int GuestCount { get; }

  private readonly ReservationStatus reservationStatus;
  public GuestId GuestId { get; }
  public BillId BillId { get; }
  public DateTime ArrivalDateTime { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Reservation(
    ReservationId reservationId,
    int guestCount,
    ReservationStatus reservationStatus,
    GuestId guestId,
    BillId billId,
    DateTime arrivalDateTime,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(reservationId)
  {
    GuestCount = guestCount;
    this.reservationStatus = reservationStatus;
    GuestId = guestId;
    BillId = billId;
    ArrivalDateTime = arrivalDateTime;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Reservation Create(
    int guestCount,
    ReservationStatus reservationStatus,
    GuestId guestId,
    BillId billId,
    DateTime arrivalDateTime) {

      return new Reservation(
        ReservationId.CreateUnique(),
        guestCount,
        reservationStatus,
        guestId,
        billId,
        arrivalDateTime,
        DateTime.UtcNow,
        DateTime.UtcNow);
  }
}