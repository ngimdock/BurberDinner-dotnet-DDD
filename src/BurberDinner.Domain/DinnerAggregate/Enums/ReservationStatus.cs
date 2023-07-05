

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public class ReservationStatus {

  public static readonly string RESERVED = "RESERVED";
  public static readonly string PENDING_GUEST_CONFIRMATION = "PENDING_GUEST_CONFIRMATION";
 
  public static readonly string CANCELLED = "CANCELLED";
}