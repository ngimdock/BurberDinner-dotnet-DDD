


using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.Common.ValueObjects;

public sealed class Price: ValueObject {

  public int Amount { get; private set; }
  public string Currency { get; private set; }

  private Price(int amount, string currency) {
   Amount = amount;
   Currency = currency;
  }

  public static Price Create(int amount, string currency) {
    return new Price(amount, currency);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Amount;
    yield return Currency;
  }
}
