
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuSectionId : ValueObject
{
  public Guid Value { get; }

  private MenuSectionId(Guid value) {
    Value = value;
  }

  public static MenuSectionId CreateUnique() {
    return new MenuSectionId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
