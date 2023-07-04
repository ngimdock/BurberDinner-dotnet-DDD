
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuItemId : ValueObject
{
  public Guid Value { get; private set; }

  private MenuItemId(Guid value) {
    Value = value;
  }

  public static MenuItemId CreateUnique() {
    return new MenuItemId(new Guid());
  }

  public static MenuItemId Create(Guid value) {
    return new MenuItemId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
