using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Dinners.ValueObjects;



public sealed class ReservationId: ValueObject {

  public Guid Value { get; }

  private ReservationId(Guid value) {
    Value = value;
  }

  public static ReservationId CreateUnique() {
    return new ReservationId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}