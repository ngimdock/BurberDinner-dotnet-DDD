using BurberDinner.Application.Authentication.Common;
using MediatR;

namespace BurberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
  string FisrtName, 
  string LastName, 
  string Email, 
  string Password): IRequest<AuthenticationResult>;