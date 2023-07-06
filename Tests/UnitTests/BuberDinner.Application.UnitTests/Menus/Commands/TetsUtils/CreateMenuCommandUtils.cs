using System;
using System.Collections.Generic;
using System.Linq;

using BurberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.constants;



namespace BuberDinner.Application.UnitTests.Menus.Commands.TetsUtils;

public class CreateMenuCommandUtils {

  public static CreateMenuCommand CreateCommand(
    List<MenuSectionCommand>? sections = null
  ) => 
    new CreateMenuCommand(
      Constants.Host.Id.ToString()!,
      Constants.Menu.Name,
      Constants.Menu.Description,
      sections ?? CreateSectionsCommand()
    );

  public static List<MenuSectionCommand> CreateSectionsCommand(
    int sectionsCout = 1,
    List<MenuItemCommand>? items = null
  ) => 
    Enumerable.Range(0, sectionsCout)
      .Select(index => new MenuSectionCommand(
        Constants.Menu.SectionNameFromIndex(index),
        Constants.Menu.SectionDescriptionFromIndex(index),
        items ?? CreateItemsCommand()
      ))
      .ToList();
    
  
  public static List<MenuItemCommand> CreateItemsCommand(int sectionsCout = 1) =>
    Enumerable.Range(0, sectionsCout)
      .Select(index => new MenuItemCommand(
        Constants.Menu.ItemNameFromIndex(index),
        Constants.Menu.ItemDescriptionFromIndex(index)
      ))
      .ToList();
}