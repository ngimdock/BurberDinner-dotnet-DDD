using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public sealed class ReservationId: ValueObject {

  public Guid Value { get; private set; }

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