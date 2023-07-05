using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.UserAggregate.ValueObjects;

namespace BurberDinner.Domain.UserAggregate;

public sealed class User: AggregateRoot<UserId> {


  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public string Email { get; private set; }
  public string Password { get; private set; }
  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private User(
    UserId userId,
    string firstName,
    string lastName,
    string email,
    string password,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(userId)
  {
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    Password = password;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static User Create(
    string firstName,
    string lastName,
    string email,
    string password) {

      return new User(
        UserId.CreateUnique(),
        firstName,
        lastName,
        email,
        password,
        DateTime.UtcNow,
        DateTime.UtcNow);
  }
}