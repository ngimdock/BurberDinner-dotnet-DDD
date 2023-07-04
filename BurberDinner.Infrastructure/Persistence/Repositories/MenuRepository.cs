using BurberDinner.Application.Common.Interfaces.Persistence;
using BurberDinner.Domain.Menu;

namespace BurberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
  private readonly BuberDinnerDbContext _dbContext;

  public MenuRepository(BuberDinnerDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public void Add(Menu menu)
  {
    _dbContext.Add(menu);
    _dbContext.SaveChanges();
  }
}
