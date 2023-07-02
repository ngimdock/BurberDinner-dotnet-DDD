

using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Guest.ValueObjects;


public sealed class GuestId: ValueObject {

  public Guid Value { get; }

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
