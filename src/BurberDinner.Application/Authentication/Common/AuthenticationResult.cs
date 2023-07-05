using BurberDinner.Domain.entities;

namespace BurberDinner.Application.Authentication.Common;


public record AuthenticationResult(
  User user,
  string Token
);
