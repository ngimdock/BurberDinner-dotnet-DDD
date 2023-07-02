using Microsoft.AspNetCore.Mvc;

using BuberDinner.Contracts.Authentication;
using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using BurberDinner.Api.Controllers;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController: ApiController {

  // private readonly ISender _mediator;
  private readonly RegisterCommandHandler _registerCommandHandler;
  private readonly LoginQueryHandler _loginQueryHandler;

  private readonly IMapper _mapper;
  public AuthenticationController(
    // ISender mediator,
    RegisterCommandHandler registerCommandHandler,
    LoginQueryHandler loginQueryHandler,
    IMapper mapper
  ) {

    // _mediator = mediator;
    _registerCommandHandler = registerCommandHandler;
    _loginQueryHandler = loginQueryHandler;
    _mapper = mapper;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request){
 
    var command = _mapper.Map<RegisterCommand>(request);
    // var authResult = await _mediator.Send(command);

    var authResult = await _registerCommandHandler.Handle(command);

    var response = _mapper.Map<AuthenticationResponse>(authResult);
    
    return Ok(response);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request) {

    var query = _mapper.Map<LoginQuery>(request);

    var authResult = await _loginQueryHandler.Handle(query);

    var response = _mapper.Map<AuthenticationResponse>(authResult);
    
    return Ok(response);
  }
}