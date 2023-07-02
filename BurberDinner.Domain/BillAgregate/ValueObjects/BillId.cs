using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.BillAgregate.ValueObjects;

public sealed class BillId: ValueObject {

  public Guid Value { get; }

  public BillId(Guid value) {
    Value = value;
  }

  public static BillId CreateUnique() {
    return new BillId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}