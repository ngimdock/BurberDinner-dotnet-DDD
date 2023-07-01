using BurberDinner.Application.Authentication.Common;
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.entities;
using MediatR;
using BurberDinner.Application.Common.Interfaces.Authentication;

namespace BurberDinner.Application.Authentication.Commands.Register;


public class RegisterCommandHandler 
{

  private readonly IUserRepository _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  public RegisterCommandHandler(
    IUserRepository userRepository, 
    IJwtTokenGenerator jwtTokenGenerator) 
  {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<AuthenticationResult> Handle(
    RegisterCommand command)
  {

    await Task.CompletedTask;
    
    var user =  _userRepository.GetUserByEmail(command.Email);

    if(user is not null) 
      throw new Exception("User with given email already exists.");
    

    var newUser = new User(
      Email: command.Email, 
      FirstName: command.FisrtName, 
      LastName: command.LastName,
      Password: command.Password);

     _userRepository.Add(newUser);
    
    // var token = _jwtTokenGenerator.GenerateToken(newUser);

    return new AuthenticationResult(
      newUser,
      "token");
  
  }
}
