using BurberDinner.Domain.BillAgregate.ValueObjects;
using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.GuestAggregate.ValueObjects;

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : AggregateRoot<ReservationId>
{
  public int GuestCount { get; private set; }

  private readonly ReservationStatus reservationStatus;
  public GuestId GuestId { get; private set; }
  public BillId BillId { get; private set; }
  public DateTime ArrivalDateTime { get; private set; }
  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }
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