

namespace BurberDinner.Application.Services.Authentication;


public interface IAuthenticationService 
{
  AuthenticationResult Register(string firstname, string lastname, string email, string password);
  AuthenticationResult Login(string email, string password);
} 