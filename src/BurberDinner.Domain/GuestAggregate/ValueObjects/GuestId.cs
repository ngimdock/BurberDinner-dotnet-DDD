

using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId: ValueObject {

  public Guid Value { get; private set; }

  private GuestId(Guid value) {
    Value = value;
  }

  public static GuestId CreateUnique() {
    return new GuestId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
