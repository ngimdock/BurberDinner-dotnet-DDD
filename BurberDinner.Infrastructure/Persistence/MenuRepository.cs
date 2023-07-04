using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.Menu;

public class MenuRepository : IMenuRepository
{
  private readonly  static List<Menu> _menus = new();
  public void Add(Menu menu)
  {
    _menus.Add(menu);
  }
}
