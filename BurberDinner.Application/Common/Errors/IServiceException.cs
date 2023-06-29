using System.Net;


namespace BurberDinner.Application.Common.Errors;

public interface IServiceException {

  public HttpStatusCode statusCode { get; }
  public String ErrorMessage { get; }
}