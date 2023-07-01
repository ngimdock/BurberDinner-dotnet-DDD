
using MediatR;
using BurberDinner.Application.Authentication.Common;
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Application.Common.Interfaces.Authentication;

namespace BurberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginQueryHandler(
    IUserRepository userRepository, 
    IJwtTokenGenerator jwtTokenGenerator)
  {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }
  public async Task<AuthenticationResult> Handle(LoginQuery query)
  {
    
    var user = _userRepository.GetUserByEmail(query.Email);

    if(user is null) 
      throw new Exception("User not exists");

    if(user.Password != query.Password)
      throw new Exception("Invalid credentials.");

    // var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      "token");
  }
}