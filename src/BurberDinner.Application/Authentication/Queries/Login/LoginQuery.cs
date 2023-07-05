
using BurberDinner.Application.Authentication.Common;
using MediatR;
namespace BurberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
  string Email, 
  string Password): IRequest<AuthenticationResult>;