
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.MenuReview.ValueObjects;
public sealed class MenuReviewId: ValueObject {

  private  Guid Value { get; }

  private MenuReviewId(Guid value) {
    Value = value;
  }

  public static MenuReviewId CreateUnique() {
    return new MenuReviewId(new Guid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}