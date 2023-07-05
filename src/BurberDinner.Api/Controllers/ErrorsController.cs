using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using BurberDinner.Application.Common.Errors;

namespace BurberDinner.Api.Controllers;


public class ErrorsController: ControllerBase {

  [Route("/error")]
  public IActionResult Error() {

    Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    // var (statusCode, message) = exception switch {
    //   IServiceException serviceException => ((int)serviceException.statusCode, serviceException.ErrorMessage),
    //   _ => (StatusCodes.Status500InternalServerError, "And unexpected error occured."),
    // };

    return Problem(title: exception?.Message);
  }
}