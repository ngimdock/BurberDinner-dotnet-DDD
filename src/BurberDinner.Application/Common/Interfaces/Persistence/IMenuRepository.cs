using BurberDinner.Domain.Menu;

namespace BurberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository {
  void Add(Menu menu);
}
