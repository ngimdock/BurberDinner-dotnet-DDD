


using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.UserAggregate.ValueObjects;
public sealed class UserId: ValueObject {

  public Guid Value { get; private set; }

  public UserId(Guid value) {
    Value = value;
  }

  public static UserId CreateUnique() {
    return new UserId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}