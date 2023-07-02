
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Menu.ValueObjects;


public sealed class MenuItemId : ValueObject
{
  public Guid Value { get; }

  private MenuItemId(Guid value) {
    Value = value;
  }

  public static MenuItemId CreateUnique() {
    return new MenuItemId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
