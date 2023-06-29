// using BurberDinner.Api.Middlewares;
using BurberDinner.Api.Filters;
using BurberDinner.Application;
using BurberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlerFilterAttribute>());
}

var app = builder.Build();

{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}