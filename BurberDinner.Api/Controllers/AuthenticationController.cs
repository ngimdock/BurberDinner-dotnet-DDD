using Microsoft.AspNetCore.Mvc;

using BuberDinner.Contracts.Authentication;
using MediatR;
using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Queries.Login;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: ControllerBase {

  // private readonly ISender _mediator;


  private readonly RegisterCommandHandler _registerCommandHandler;
  private readonly LoginQueryHandler _loginQueryHandler;
  public AuthenticationController(
    // ISender mediator,
    RegisterCommandHandler registerCommandHandler,
    LoginQueryHandler loginQueryHandler
  ) {

    // _mediator = mediator;
    _registerCommandHandler = registerCommandHandler;
    _loginQueryHandler = loginQueryHandler;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request){
 
    var command = new RegisterCommand(
      FisrtName: request.Firstname,
      LastName: request.Lastname,
      Email: request.Email,
      Password: request.Password
      );

    // var authResult = await _mediator.Send(command);

    var authResult = await _registerCommandHandler.Handle(command);

    var response = new AuthenticationResponse(
      authResult.user.Id, 
      authResult.user.FirstName, 
      authResult.user.LastName, 
      authResult.user.Email, 
      authResult.Token);
    
    return Ok(response);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request) {

    var query = new LoginQuery(request.Email, request.Password);

    var authResult = await _loginQueryHandler.Handle(query);

    var response = new AuthenticationResponse(
      authResult.user.Id, 
      authResult.user.FirstName, 
      authResult.user.LastName, 
      authResult.user.Email, 
      authResult.Token);
    
    return Ok(response);
  }
}