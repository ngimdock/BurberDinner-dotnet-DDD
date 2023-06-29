using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BurberDinner.Api.Filters;

public class ErrorHandlerFilterAttribute: ExceptionFilterAttribute {

  public override void OnException(ExceptionContext context) {

    var exception = context.Exception;

    var problemDetails = new ProblemDetails
    {
      Type = "https://link-to-http-500-exception",
      Title = "An error occured while processing your request.",
      Detail = exception.Message,
      Status = (int)HttpStatusCode.InternalServerError,
      Instance = context.RouteData.ToString(),
    };

    context.Result = new ObjectResult(problemDetails);

    context.ExceptionHandled = true;
  }
}
 