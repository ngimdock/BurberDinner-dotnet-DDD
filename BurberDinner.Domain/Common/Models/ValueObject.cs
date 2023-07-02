
namespace BurberDinner.Domain.Common.Models;

public abstract class ValueObject: IEquatable<ValueObject> {

  public abstract IEnumerable<object> GetEqualityComponents(); // Return the same object with properties in a defined order

  public override bool Equals(object? obj)
  {
    if(obj is null || obj.GetType() != GetType()) return false;

    var valueObject = (ValueObject)obj;

    var propertiesAreEqueals = GetEqualityComponents()
                                  .SequenceEqual(valueObject.GetEqualityComponents());

    return propertiesAreEqueals;
  }

  public static bool operator ==(ValueObject left, ValueObject right) {
    return Equals(left, right);
  }

    public static bool operator !=(ValueObject left, ValueObject right) {
    return !Equals(left, right);
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x^y);
  }

  public bool Equals(ValueObject? other)
  {
    return Equals((object?)other);
  }
}

public class Price: ValueObject {
  public decimal Amount { get; private set; }
  public decimal Currency { get; private set; }


  public Price(decimal amount, decimal currentcy) {
    Amount = amount;
    Currency = currentcy;
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Amount;
    yield return Currency;
  }
}