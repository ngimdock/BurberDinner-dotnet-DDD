

using FluentValidation;

namespace BurberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand> {

  public CreateMenuCommandValidator() {
    RuleFor(x => x.Name)
      .NotEmpty()
      .MinimumLength(3)
      .MaximumLength(200);
    
    RuleFor(x => x.Description)
      .NotEmpty();

    RuleFor(x => x.Sections)
      .NotEmpty();
  }
}