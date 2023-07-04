
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.entities;

public class UserRepository : IUserRepository
{


  private readonly  static List<User> _users = new();
  public void Add(User user)
  {
    _users.Add(user);
  }

  public User? GetUserByEmail(string Email)
  {
    return _users.SingleOrDefault(user => user.Email == Email);
  }
}