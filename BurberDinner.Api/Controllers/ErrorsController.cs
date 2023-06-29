using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BurberDinner.Api.Controllers;


public class ErrorsController: ControllerBase {

  [Route("/error")]
  public IActionResult Error() {

    Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Problem(title: exception?.Message);
  }
}