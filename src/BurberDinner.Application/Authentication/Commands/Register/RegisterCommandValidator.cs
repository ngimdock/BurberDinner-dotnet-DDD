using FluentValidation;

namespace BurberDinner.Application.Authentication.Commands.Register;

// This is and application layer validation and we also have a domain layer validation
public class RegisterCommandValidator: AbstractValidator<RegisterCommand> {

  public RegisterCommandValidator() {
    RuleFor(x => x.FisrtName).NotEmpty();
    RuleFor(x => x.LastName).NotEmpty();
    RuleFor(x => x.Email).NotEmpty();
    RuleFor(x => x.Password).NotEmpty();
  }
}
