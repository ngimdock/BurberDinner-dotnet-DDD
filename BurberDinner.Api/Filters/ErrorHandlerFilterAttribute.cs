using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BurberDinner.Api.Filters;

public class ErrorHandlerFilterAttribute: ExceptionFilterAttribute {

  public override void OnException(ExceptionContext context) {

    var exception = context.Exception;

    context.Result = new ObjectResult(new { error = exception.Message })
    {
      StatusCode = 500
    };

    context.ExceptionHandled = true;
  }
}
 