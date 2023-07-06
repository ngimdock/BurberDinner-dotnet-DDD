

using System.Collections.Generic;
using BuberDinner.Application.UnitTests.Menus.Commands.TetsUtils;
using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Application.Menus.Commands.CreateMenu;
using Moq;
using Xunit;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;



public class CreateMenuCommandHandlerTests {

    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

  public CreateMenuCommandHandlerTests()
  {
    _mockMenuRepository = new Mock<IMenuRepository>();
    _handler = new CreateMenuCommandHandler(_mockMenuRepository);
  }

  /*  FOR TEST NAMING CONVENSION
    1. SUB: Logical compose
    2. SCENARIO: What we are testing
    3. Expected outcome: What we expect de logical component to do
  */
  [Theory]
  [MemberData(nameof(ValidCreateMenuCommands))]
  public async void HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu() {

    
    // 1) ARRANGE
    // Get hold of a valid menu
    var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

    // 2) ACT
    // Invake the handler
    var menu = await _handler.Handle(createMenuCommand);

    // 3) ASSERT
    // 3.1. Validate correct menu created base on command
    menu.ValidateCreatedFrom(createMenuCommand);

    // 3.2. Menu added to repository
    _mockMenuRepository.Verify(m => m.Add(menu), Times.Once);

  }


  public static IEnumerable<object[]> ValidCreateMenuCommands() {
    yield return new[] { CreateMenuCommandUtils.CreateCommand() };
    
    yield return new[] { CreateMenuCommandUtils.CreateCommand(
      sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionsCout: 3)
    ) };

    yield return new[] { CreateMenuCommandUtils.CreateCommand(
      sections: CreateMenuCommandUtils
                  .CreateSectionsCommand(
                    sectionsCout: 2, 
                    items: CreateMenuCommandUtils.CreateItemsCommand(sectionsCout: 4)
                  )
    ) };
  }
}