using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.entities;

namespace BurberDinner.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{

  private readonly IUserRepository _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(
    IUserRepository userRepository, 
    IJwtTokenGenerator jwtTokenGenerator)
  {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public  AuthenticationResult Register(
    string firstname, 
    string lastname, 
    string email, 
    string password)
  {

    var userExists =  _userRepository.GetUserByEmail(email);

    if(userExists is not null) 
      throw new Exception("User with given exception already exists.");
    

    var newUser = new User(
      Email: email, 
      FirstName: firstname, 
      LastName: lastname,
      Password: password);

     _userRepository.Add(newUser);
    
    // var token = _jwtTokenGenerator.GenerateToken(newUser);

    return new AuthenticationResult(
      newUser,
      "token");
  }

  public AuthenticationResult Login(string email, string password)
  {
    var user = _userRepository.GetUserByEmail(email);

    if(user is null) 
      throw new Exception("User not exists");

    if(user.Password != password)
      throw new Exception("Invalid credentials.");

    // var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      "token");
  }
}
