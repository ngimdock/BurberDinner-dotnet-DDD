

using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuId : ValueObject  {

  public Guid Value { get; private set; }

  private MenuId(Guid value) {
    Value = value;
  }

  public static MenuId CreateUnique() {
    
    // @TODO: Enforce invariants
    return new MenuId( new Guid());
  }

  public static MenuId Create(Guid value) {

    // @TODO: Enforce invariants
    return new MenuId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
