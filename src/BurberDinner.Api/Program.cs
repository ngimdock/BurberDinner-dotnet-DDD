// using BurberDinner.Api.Middlewares;
using BurberDinner.Api;
using BurberDinner.Application;
using BurberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlerFilterAttribute>());
    builder.Services.AddControllers();
    
}

var app = builder.Build();

{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    // app.UseAuthentication();
    // app.UseAuthorization();
    app.MapControllers();
    app.Run();

}