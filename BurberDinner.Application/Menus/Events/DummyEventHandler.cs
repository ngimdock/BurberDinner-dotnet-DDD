

using MediatR;

namespace BurberDinner.Application.Menus.Events;

public class DummyEventHandler : INotificationHandler<MenuCreated>
{
  public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
  {
    var CreatedMenu = notification.Menu;
    Console.Write(CreatedMenu);
    
    return Task.CompletedTask;
  }
}