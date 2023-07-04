
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.HostAggregate.ValueObjects;
public sealed class HostId: ValueObject {

  public  Guid Value { get; }

  private HostId(Guid value) {
    Value = value;
  }

  public static HostId CreateUnique() {
    return new HostId(new Guid());
  }

  public static HostId Create(Guid value) {
    return new HostId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}