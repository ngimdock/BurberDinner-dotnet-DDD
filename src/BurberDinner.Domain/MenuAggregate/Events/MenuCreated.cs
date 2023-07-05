using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Menu;

public class MenuCreated: IDomainEvent {

  public Menu Menu { get; private set; }

  public MenuCreated(Menu menu)
  {
    Menu = menu;
  }
}
