// using System.Net;
// using System.Text.Json;
// namespace BurberDinner.Api.Middlewares;


// public class ErrorHandlingMiddleware {

//   private readonly RequestDelegate _next

//   public ErrorHandlingMiddleware(RequestDelegate next) {
//     _next = next;
//   }

//   public async Task Invoke(HttpContext context) {

//     try {

//       await _next(context);

//     }catch(Exception ex) {

//       await HandleExceptionAsync(context, ex);

//     }
//   }

//   private static Task HandleExceptionAsync(HttpContext context, Exception exception) {

//     context.Response.ContentType = "application/json";
//     var code = HttpStatusCode.InternalServerError;
//     context.Response.StatusCode = (int)code;
//     var result = JsonSerializer.Serialize(new { error = exception.Message });

//     return context.Response.WriteAsync(result);
//   }
// }