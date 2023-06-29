using BurberDinner.Domain.entities;
namespace BurberDinner.Application.Services.Authentication;

public record AuthenticationResult(
  User user,
  string Token
);
