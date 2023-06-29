using System;

using BurberDinner.Application.Common.Interfaces.Authentication;

namespace BurberDinner.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{

  // private readonly IJwtTokenGenerator _jwtTokenGenerator;

  // public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
  // {
  //   _jwtTokenGenerator = jwtTokenGenerator;
  // }

  public AuthenticationResult Register(string firstname, string lastname, string email, string password)
  {

    Guid userId = new Guid();

    // var token = _jwtTokenGenerator.GenerateToken(userId, firstname, lastname);

    return new AuthenticationResult(
     userId,
      firstname, 
      lastname, 
      email, 
      "token");
  }

  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(
      new Guid(), 
      "firstname", 
      "lastname", 
      email, 
      "token");
  }
}