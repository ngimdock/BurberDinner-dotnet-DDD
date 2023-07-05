
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Common.ValueObjects;

public sealed class Rating: ValueObject {

  public float Value { get; private set; }

  private Rating(float value) {
    Value = value;
  }

  public static Rating Create(float value) {
    return new Rating(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}