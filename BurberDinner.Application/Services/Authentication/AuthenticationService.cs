
namespace BurberDinner.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{

  public AuthenticationResult Register(string firstname, string lastname, string email, string password)
  {
    return new AuthenticationResult(
      new Guid(), 
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