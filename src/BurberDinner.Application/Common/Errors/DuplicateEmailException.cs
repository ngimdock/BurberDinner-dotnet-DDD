using System.Net;

namespace BurberDinner.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
  public HttpStatusCode statusCode => HttpStatusCode.Conflict;

  public string ErrorMessage => "Email already exists.";
}