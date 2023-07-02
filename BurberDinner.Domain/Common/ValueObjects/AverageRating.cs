

using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating: ValueObject {
  public double Value { get; private set; }
  public int NumRatings { get; private set; }

  private AverageRating(double value, int numRatings) {
    Value = value;
    NumRatings = numRatings;
  }

  public static AverageRating Create(
    double value = 0,
    int numRatings = 0) {

    return new AverageRating(value, numRatings);
  }
  
  public void AddRating(Rating rating) {
    Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
  }

  public void RemoveRating(Rating rating) {
    Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
