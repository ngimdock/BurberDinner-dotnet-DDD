

using BurberDinner.Application.Authentication.Commands.Register;
using BurberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;


public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, AuthenticationResult>
{
  private readonly IValidator<RegisterCommand> _validator;
  public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator) {
    _validator = validator;
  }
  public async Task<AuthenticationResult> Handle(RegisterCommand request, RequestHandlerDelegate<AuthenticationResult> next, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request);


    if(validationResult.IsValid)  return await next();
    

    var errors = validationResult.Errors
        .ConvertAll(validationFailure => Error.Validation(
              validationFailure.PropertyName, 
              validationFailure.ErrorMessage));

    return errors;
  }
}