
using BurberDinner.Domain.entities;

namespace BurberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository {

  User? GetUserByEmail(String Email);

  void Add(User user);
}