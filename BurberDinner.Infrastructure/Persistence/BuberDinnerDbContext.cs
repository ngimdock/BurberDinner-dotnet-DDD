using BurberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace BurberDinner.Infrastructure.Persistence;


public class BuberDinnerDbContext: DbContext {
  
  public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
    : base(options) 
  {

  }
  public DbSet<Menu> Menus { get; set; } = null!;
}