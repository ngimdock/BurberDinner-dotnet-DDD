
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public sealed class DinnerId: ValueObject {

  private  Guid Value { get; }

  private DinnerId(Guid value) {
    Value = value;
  }

  public static DinnerId CreateUnique() {
    return new DinnerId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}